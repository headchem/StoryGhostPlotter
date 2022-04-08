using System;
using System.Threading.Tasks;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.Cosmos;
using StoryGhost.Util;
using StoryGhost.Models;
using StoryGhost.Finetuning.Models;
using CsvHelper;
using System.Globalization;
using System.Text.Json;

namespace StoryGhost.Util;
public class CreateFinetuningDataset
{
    /// <summary>IMPORTANT: if this ever changes, you'll have to re-fine-tune ALL models! This is also referenced by Factory.cs</summary>
    public static string PromptSuffix = " ->";
    public static string CompletionStopSequence = "###";

    private readonly CosmosClient _db;

    public CreateFinetuningDataset(CosmosClient db)
    {
        _db = db;
    }

    [FunctionName("CreateLogLineFinetuningDataset")] // NOTE: "Admin" is a reserved route by Azure Functions, so we call ours something different (SGAdmin)
    public async Task<IActionResult> CreateLogLineFinetuningDataset([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "SGAdmin/CreateLogLineFinetuningDataset")] HttpRequest req, ILogger log)
    {
        var user = StaticWebAppsAuth.Parse(req);

        if (!user.IsInRole("admin")) return new UnauthorizedResult(); // even though I defined allowed roles per route in staticwebapp.config.json, I was still able to reach this point via Postman on localhost. So, I'm adding this check here just in case.

        var formdata = await req.ReadFormAsync();
        IFormFile file = req.Form.Files["logLineFile"];
        var csvStr = await ReadFormFileAsync(file);

        using var reader = new StringReader(csvStr);
        using var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);
        var rows = csvReader.GetRecords<LogLineRow>();

        rows = rows.Where(r => r.HasAdult == "No" && r.HasDisturbing == "No").ToList();

        // randomize row order just in case
        rows = rows.OrderBy(a => Guid.NewGuid()).ToList();


        var finetuningRows = new List<FinetuningRow>();

        foreach (var row in rows)
        {
            var prompt = string.Join(", ", row.Genres);
            var completion = row.Overview;// + " --- " + row.Title; // my theory is that putting the title at the end will force the model to come up with a more creative title, since it has seen a bunch of creative words before it. Otherwise, I feel like it was memorizing famous titles and then outputting known plot summaries of those titles. I think this will work because GPT-3 only reads "forward" so it can't know about the title until the very end. UPDATE: this didn't work, and it just repeated well known titles instead of coming up new ones

            finetuningRows.Add(getFinetuningRow(prompt, completion));
        }

        var resultText = string.Join("\n", finetuningRows.Select(r => getJSONLRow(r)));

        var results = new
        {
            Text = resultText
        };

        return new OkObjectResult(results);
    }

    public async Task<string> ReadFormFileAsync(IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            return await Task.FromResult((string)null);
        }

        using (var reader = new StreamReader(file.OpenReadStream()))
        {
            return await reader.ReadToEndAsync();
        }
    }

    [FunctionName("CreateCharacterFinetuningDataset")] // NOTE: "Admin" is a reserved route by Azure Functions, so we call ours something different
    public async Task<IActionResult> CreateCharacterFinetuningDataset([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "SGAdmin/CreateCharacterFinetuningDataset")] HttpRequest req, ILogger log)
    {
        var user = StaticWebAppsAuth.Parse(req);

        if (!user.IsInRole("admin")) return new UnauthorizedResult(); // even though I defined allowed roles per route in staticwebapp.config.json, I was still able to reach this point via Postman on localhost. So, I'm adding this check here just in case.

        var finetuningRows = new List<FinetuningRow>();

        var plots = await getTrainingPlots();

        foreach (var plot in plots)
        {
            // get single Plot
            var plotContainer = _db.GetContainer(databaseId: "Plotter", containerId: "Plots");
            var plotResponse = await plotContainer.ReadItemAsync<Plot>(plot.Id, new PartitionKey(plot.UserId));
            var plotObj = plotResponse.Resource;

            if (plotObj.Characters != null)
            {
                foreach (var character in plotObj.Characters)
                {
                    if (string.IsNullOrWhiteSpace(character.Description)) continue;

                    var prompt = PersonalityDescription.GetCharacterPrompt(character);
                    var completion = character.Description;

                    finetuningRows.Add(getFinetuningRow(prompt, completion));
                }
            }
        }

        var resultText = string.Join("\n", finetuningRows.Select(r => getJSONLRow(r)));

        var results = new
        {
            Text = resultText
        };

        return new OkObjectResult(results);
    }



    [FunctionName("CreateSequenceFinetuningDataset")] // NOTE: "Admin" is a reserved route by Azure Functions, so we call ours something different
    public async Task<IActionResult> CreateSequenceFinetuningDataset([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "SGAdmin/CreateSequenceFinetuningDataset")] HttpRequest req, ILogger log)
    {
        var user = StaticWebAppsAuth.Parse(req);

        if (!user.IsInRole("admin")) return new UnauthorizedResult(); // even though I defined allowed roles per route in staticwebapp.config.json, I was still able to reach this point via Postman on localhost. So, I'm adding this check here just in case.

        var targetSequence = req.Query["targetSequence"][0];

        var finetuningRows = new List<FinetuningRow>();

        var plots = await getTrainingPlots();

        foreach (var plot in plots)
        {
            // get single Plot
            var plotContainer = _db.GetContainer(databaseId: "Plotter", containerId: "Plots");
            var plotResponse = await plotContainer.ReadItemAsync<Plot>(plot.Id, new PartitionKey(plot.UserId));
            var plotObj = plotResponse.Resource;

            //var (completionStartSequenceName, completionEndSequenceName) = getStartAndEndSequenceNames(part);
            //var completionPartSequences = getSequencesBetween(plotObj.Sequences, completionStartSequenceName, completionEndSequenceName);

            var promptSequenceText = GetSequenceTextUpTo(targetSequence, plotObj);
            var completionText = plotObj.Sequences.Where(s => s.SequenceName == targetSequence).First().Text;

            var prompt = Factory.GetSequencePartPrompt(targetSequence, plotObj, promptSequenceText);// "prompt for " + part + "\n\n" + promptSequenceText.Trim();
            var completion = completionText.Trim();

            finetuningRows.Add(getFinetuningRow(prompt, completion));
        }

        var resultText = string.Join("\n", finetuningRows.Select(r => getJSONLRow(r)));

        var results = new
        {
            Text = resultText
        };

        return new OkObjectResult(results);
    }

    /// <summary>Given a targetSequence, return all sequence text up to but not including the target sequence.</summary>
    public static string GetSequenceTextUpTo(string targetSequenceExclusive, Plot plot)
    {
        var result = "";

        foreach (var sequence in plot.Sequences)
        {
            if (sequence.SequenceName == targetSequenceExclusive) return result;

            result += sequenceToText(sequence);
        }

        throw new Exception($"Incorrect targetSequenceExclusive: \"{targetSequenceExclusive}\"");
    }

    // public static string GetPromptSequenceText(string targetSequenceExclusive, Plot plotObj)
    // {
    //     var promptSequenceText = "TODO based on targetSequenceExclusive: " + targetSequenceExclusive;

    //     // if (part == "middle")
    //     // {
    //     //     var (promptStartSequenceName, promptEndSequenceName) = getStartAndEndSequenceNames("start");
    //     //     var promptPartSequences = getSequencesBetween(plotObj.Sequences, promptStartSequenceName, promptEndSequenceName);

    //     //     promptSequenceText = sequencesToText(promptPartSequences);
    //     // }
    //     // else if (part == "ending")
    //     // {
    //     //     var (startPromptStartSequenceName, startPromptEndSequenceName) = getStartAndEndSequenceNames("start");
    //     //     var (middlePromptStartSequenceName, middlePromptEndSequenceName) = getStartAndEndSequenceNames("middle");

    //     //     var startPromptPartSequences = getSequencesBetween(plotObj.Sequences, startPromptStartSequenceName, startPromptEndSequenceName);
    //     //     var middlePromptPartSequences = getSequencesBetween(plotObj.Sequences, middlePromptStartSequenceName, middlePromptEndSequenceName);
    //     //     var promptPartSequences = startPromptPartSequences.Concat(middlePromptPartSequences);

    //     //     promptSequenceText = sequencesToText(startPromptPartSequences) + sequencesToText(middlePromptPartSequences);
    //     // }

    //     return promptSequenceText;
    // }

    private static string sequenceToText(UserSequence sequence)
    {
        var results = "";

        results += $"{sequence.SequenceName.ToUpper()}: {sequence.Text}\n\n";

        return results;
    }

    // private static (string, string) getStartAndEndSequenceNames(string part)
    // {
    //     return part switch
    //     {
    //         "start" => ("", "Fun And Games"),
    //         "middle" => ("Fun And Games", "Dark Night Of The Soul"),
    //         "ending" => ("Dark Night Of The Soul", "Cooldown"),
    //         _ => throw new ArgumentException(message: "invalid completion type value", paramName: nameof(part)),
    //     };
    // }

    // pass in startSequenceInclusive="" to start from very beginning (Opening Image)
    // private static List<UserSequence> getSequencesBetween(List<UserSequence> allSequences, string startSequenceExclusive, string endSequenceInclusive)
    // {
    //     var results = new List<UserSequence>();

    //     var foundStart = false;

    //     foreach (var sequence in allSequences)
    //     {
    //         if (foundStart || string.IsNullOrWhiteSpace(startSequenceExclusive))
    //         {
    //             results.Add(sequence);
    //         }

    //         if (string.IsNullOrWhiteSpace(startSequenceExclusive) || sequence.SequenceName == startSequenceExclusive)
    //         {
    //             foundStart = true;
    //         }

    //         if (sequence.SequenceName == endSequenceInclusive)
    //         {
    //             return results;
    //         }
    //     }

    //     return null;
    // }

    private async Task<List<Plot>> getTrainingPlots()
    {
        var container = _db.GetContainer(databaseId: "Plotter", containerId: "Users");
        var userId = "ef1494647e3f4fe69890dfb8b41431a1"; // jdparsons.dev@gmail.com - all of the finetuning datapoints have been added to this specific account (filter out the dedicated "TESTING" plot)
        var userResponse = await container.ReadItemAsync<StoryGhost.Models.User>(userId, new PartitionKey(userId));
        var existingUserObj = userResponse.Resource;
        // filter out deleted plots
        existingUserObj.PlotReferences = existingUserObj.PlotReferences.Where(p => p.IsDeleted == false).ToList();

        var results = new List<Plot>();

        foreach (var plotRef in existingUserObj.PlotReferences)
        {
            var plotId = plotRef.PlotId;
            var plotContainer = _db.GetContainer(databaseId: "Plotter", containerId: "Plots");
            var plotResponse = await plotContainer.ReadItemAsync<Plot>(plotId, new PartitionKey(userId));
            var plotObj = plotResponse.Resource;

            if (plotObj.Title.ToLower().Contains("testing") == false)
            {
                results.Add(plotObj);
            }
        }

        return results;
    }

    // private List<FinetuningRow> getRows(string sequenceName, List<Plot> plots)
    // {
    //     var results = new List<FinetuningRow>();

    //     foreach (var plot in plots)
    //     {
    //         var row = getSequencePromptAndCompletion(sequenceName, plot);

    //         if (row != null)
    //         {
    //             results.Add(row);
    //         }
    //     }

    //     return results;
    // }

    // private FinetuningRow getSequencePromptAndCompletion(string sequenceName, Plot plot)
    // {
    //     var curSeqObj = plot.Sequences.Where(seq => seq.SequenceName == sequenceName).FirstOrDefault();

    //     // not all plots have all sequence types
    //     if (curSeqObj == null)
    //     {
    //         return null;
    //     }

    //     var row = new FinetuningRow();

    //     //row.SequenceName = sequenceName;
    //     row.Prompt = Factory.GetSequencePrompt(sequenceName, plot);

    //     // According to OpenAI guidelines: "Each completion should start with a whitespace due to our tokenization, which tokenizes most words with a preceding whitespace. Each completion should end with a fixed stop sequence to inform the model when the completion ends. A stop sequence could be \n, ###, or any other token that does not appear in any completion." HOWEVER, a YouTube video from OpenAI said that the preceeding space before completions wasn't needed for open-ended generation tasks.
    //     row.Completion = " " + curSeqObj.Text + StopSequence;

    //     return row;
    // }

    private string clean(string inStr)
    {
        if (inStr.IndexOf('\u2013') > -1) inStr = inStr.Replace('\u2013', '-'); // en dash
        if (inStr.IndexOf('\u2014') > -1) inStr = inStr.Replace('\u2014', '-'); // em dash
        if (inStr.IndexOf('\u2015') > -1) inStr = inStr.Replace('\u2015', '-'); // horizontal bar
        if (inStr.IndexOf('\u2017') > -1) inStr = inStr.Replace('\u2017', '_'); // double low line
        if (inStr.IndexOf('\u2018') > -1) inStr = inStr.Replace('\u2018', '\''); // left single quotation mark
        if (inStr.IndexOf('\u2019') > -1) inStr = inStr.Replace('\u2019', '\''); // right single quotation mark
        if (inStr.IndexOf('\u201a') > -1) inStr = inStr.Replace('\u201a', ','); // single low-9 quotation mark
        if (inStr.IndexOf('\u201b') > -1) inStr = inStr.Replace('\u201b', '\''); // single high-reversed-9 quotation mark
        if (inStr.IndexOf('\u201c') > -1) inStr = inStr.Replace('\u201c', '\"'); // left double quotation mark
        if (inStr.IndexOf('\u201d') > -1) inStr = inStr.Replace('\u201d', '\"'); // right double quotation mark
        if (inStr.IndexOf('\u201e') > -1) inStr = inStr.Replace('\u201e', '\"'); // double low-9 quotation mark
        if (inStr.IndexOf('\u2026') > -1) inStr = inStr.Replace("\u2026", "..."); // horizontal ellipsis
        if (inStr.IndexOf('\u2032') > -1) inStr = inStr.Replace('\u2032', '\''); // prime
        if (inStr.IndexOf('\u2033') > -1) inStr = inStr.Replace('\u2033', '\"'); // double prime

        return inStr.Trim();
    }

    private FinetuningRow getFinetuningRow(string prompt, string completion)
    {
        prompt = clean(prompt) + PromptSuffix; // Having a separator string appended to the end of the prompt makes it clearer to the fine-tuned model where the completion should begin. See https://beta.openai.com/docs/guides/fine-tuning/preparing-your-dataset for more detail and examples.
        completion = " " + clean(completion) + CompletionStopSequence;

        return new FinetuningRow
        {
            Prompt = prompt,
            Completion = completion
        };
    }

    private string getJSONLRow(FinetuningRow row)
    {
        var serializeOptions = new JsonSerializerOptions
        {
            WriteIndented = true,
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping // avoids quotes turning into \u0022
        };

        var json = JsonSerializer.Serialize(row, serializeOptions);

        json = json.Replace("\r", "").Replace("\n", "").Replace("  ", " ");


        return json;
    }
}