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
            var keywords = row.CombinedKeywordsDelim.Split(";").Select(k => k.Trim()).ToList();
            keywords = keywords.Where(k => k.Contains(",") == false).ToList(); // many keywords were long lists of character names, so we will remove them

            var prompt = Factory.GetLogLinePrompt(row.GenreList, keywords);
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

        var plots = await getTrainingPlots("character");

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

    private async Task<Plot> getPlot(Plot plot)
    {
        // get single Plot
        var plotContainer = _db.GetContainer(databaseId: "Plotter", containerId: "Plots");
        var plotResponse = await plotContainer.ReadItemAsync<Plot>(plot.Id, new PartitionKey(plot.UserId));
        var plotObj = plotResponse.Resource;

        return plotObj;
    }

    [FunctionName("CreateSequenceBlurbFinetuningDataset")] // NOTE: "Admin" is a reserved route by Azure Functions, so we call ours something different
    public async Task<IActionResult> CreateSequenceBlurbFinetuningDataset([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "SGAdmin/CreateSequenceBlurbFinetuningDataset")] HttpRequest req, ILogger log)
    {
        var user = StaticWebAppsAuth.Parse(req);
        if (!user.IsInRole("admin")) return new UnauthorizedResult(); // even though I defined allowed roles per route in staticwebapp.config.json, I was still able to reach this point via Postman on localhost. So, I'm adding this check here just in case.

        var finetuningRows = new List<FinetuningRow>();

        var plots = await getTrainingPlots("blurb");

        foreach (var plot in plots)
        {
            var plotObj = await getPlot(plot);

            foreach (var targetSequence in allFinetuningSequenceNames)
            {
                var (prompt, completion) = getSequencePromptAndCompletion(plotObj, targetSequence, "blurb");
                if (prompt == "" || completion == "") continue;

                finetuningRows.Add(getFinetuningRow(prompt, completion));
            }
        }

        finetuningRows = finetuningRows.OrderBy(r => Guid.NewGuid()).ToList(); // randomize order of rows, just in case finetuning doesn't already do this

        var resultText = string.Join("\n", finetuningRows.Select(r => getJSONLRow(r)));

        var results = new
        {
            jsonl = resultText
        };

        return new OkObjectResult(results);
    }

    [FunctionName("CreateSequenceExpandedSummaryFinetuningDataset")] // NOTE: "Admin" is a reserved route by Azure Functions, so we call ours something different
    public async Task<IActionResult> CreateSequenceExpandedSummaryFinetuningDataset([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "SGAdmin/CreateSequenceExpandedSummaryFinetuningDataset")] HttpRequest req, ILogger log)
    {
        var user = StaticWebAppsAuth.Parse(req);
        if (!user.IsInRole("admin")) return new UnauthorizedResult(); // even though I defined allowed roles per route in staticwebapp.config.json, I was still able to reach this point via Postman on localhost. So, I'm adding this check here just in case.

        var finetuningRows = new List<FinetuningRow>();

        var plots = await getTrainingPlots("expanded summary");

        foreach (var plot in plots)
        {
            var plotObj = await getPlot(plot);

            foreach (var targetSequence in allFinetuningSequenceNames)
            {
                var (prompt, completion) = getSequencePromptAndCompletion(plotObj, targetSequence, "expanded summary");
                if (prompt == "" || completion == "") continue;

                finetuningRows.Add(getFinetuningRow(prompt, completion));
            }
        }

        finetuningRows = finetuningRows.OrderBy(r => Guid.NewGuid()).ToList(); // randomize order of rows, just in case finetuning doesn't already do this

        var resultText = string.Join("\n", finetuningRows.Select(r => getJSONLRow(r)));

        var results = new
        {
            jsonl = resultText
        };

        return new OkObjectResult(results);
    }

    [FunctionName("CreateSequenceFullFinetuningDataset")] // NOTE: "Admin" is a reserved route by Azure Functions, so we call ours something different
    public async Task<IActionResult> CreateSequenceFullFinetuningDataset([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "SGAdmin/CreateSequenceFullFinetuningDataset")] HttpRequest req, ILogger log)
    {
        var user = StaticWebAppsAuth.Parse(req);
        if (!user.IsInRole("admin")) return new UnauthorizedResult(); // even though I defined allowed roles per route in staticwebapp.config.json, I was still able to reach this point via Postman on localhost. So, I'm adding this check here just in case.

        var finetuningRows = new List<FinetuningRow>();

        var plots = await getTrainingPlots("full");

        foreach (var plot in plots)
        {
            var plotObj = await getPlot(plot);

            foreach (var targetSequence in allFinetuningSequenceNames)
            {
                var (prompt, completion) = getSequencePromptAndCompletion(plotObj, targetSequence, "full");
                if (prompt == "" || completion == "") continue;

                finetuningRows.Add(getFinetuningRow(prompt, completion));
            }
        }

        finetuningRows = finetuningRows.OrderBy(r => Guid.NewGuid()).ToList(); // randomize order of rows, just in case finetuning doesn't already do this

        var resultText = string.Join("\n", finetuningRows.Select(r => getJSONLRow(r)));

        var results = new
        {
            jsonl = resultText
        };

        return new OkObjectResult(results);
    }


    // not all sequences will have a finetuning model - for example First Pinch Point. Not all stories have this sequence, so there aren't enough data points to train a model
    private List<string> allFinetuningSequenceNames = new List<string>{
        "Opening Image",
        "Setup",
        "Theme Stated",
        "Catalyst",
        "Debate",
        "B Story",
        "Break Into Two",
        "Fun And Games",
        "Midpoint",
        "Bad Guys Close In",
        "All Hope Is Lost",
        "Dark Night Of The Soul",
        "Break Into Three",
        "Climax",
        "Cooldown",
    };

    private (string, string) getSequencePromptAndCompletion(Plot plot, string targetSequence, string sequenceType)
    {
        var promptSequenceText = GetSequenceTextUpTo(targetSequence, plot, sequenceType);

        if (targetSequence != "Opening Image" && string.IsNullOrWhiteSpace(promptSequenceText))
        {
            throw new Exception($"Incomplete story, empty sequence was found in \"{plot.Title}\" at target sequence \"{targetSequence}\".");
        }

        var targetSeqObj = plot.Sequences.Where(s => s.SequenceName == targetSequence).FirstOrDefault();

        // for example, not all training stories have a B Story
        if (targetSeqObj == null)
        {
            return ("", "");
        }
        var completionText = "";

        if (sequenceType == "blurb")
        {
            completionText = targetSeqObj.Blurb;
        }
        else if (sequenceType == "expanded summary")
        {
            completionText = targetSeqObj.Text;
        }
        else if (sequenceType == "full")
        {
            completionText = targetSeqObj.Full;
        }
        else
        {
            throw new Exception($"unknown sequenceType: {sequenceType}");
        }


        var prompt = Factory.GetSequencePartPrompt(targetSequence, plot, sequenceType);
        var completion = targetSequence.ToUpper() + ": " + completionText.Trim();

        return (prompt, completion);
    }

    /// <summary>Given a targetSequence, return all sequence text up to but not including the target sequence.</summary>
    public static string GetSequenceTextUpTo(string targetSequenceExclusive, Plot plot, string sequenceType)
    {
        var result = "";

        foreach (var sequence in plot.Sequences)
        {
            if (sequence.SequenceName == targetSequenceExclusive)
            {
                return result;
            }

            result += sequenceToText(sequence, sequenceType);
        }

        //throw new Exception($"Incorrect targetSequenceExclusive: \"{targetSequenceExclusive}\"");
        return result;
    }

    private static string sequenceToText(UserSequence sequence, string sequenceType)
    {
        var results = $"{sequence.SequenceName.ToUpper()}: ";

        if (sequenceType == "blurb")
        {
            var selectedBlurbCompletion = sequence.BlurbCompletions == null ? null : sequence.BlurbCompletions.Where(c => c.IsSelected).FirstOrDefault();
            results += (selectedBlurbCompletion == null ? sequence.Blurb : selectedBlurbCompletion.Completion);
        }
        else if (sequenceType == "expanded summary")
        {
            var selectedExpandedSummaryCompletion = sequence.Completions == null ? null : sequence.Completions.Where(c => c.IsSelected).FirstOrDefault();
            results += (selectedExpandedSummaryCompletion == null ? sequence.Text : selectedExpandedSummaryCompletion.Completion);
        }
        else if (sequenceType == "full")
        {
            var selectedFullCompletion = sequence.FullCompletions == null ? null : sequence.FullCompletions.Where(c => c.IsSelected).FirstOrDefault();
            results += (selectedFullCompletion == null ? sequence.Full : selectedFullCompletion.Completion);
        }

        results += "\n\n";

        return results;
    }

    ///<summary>Returns a list of Plots where only the PlotId and UserId are populated (the plot references)</summary>
    private async Task<List<Plot>> getTrainingPlots(string sequenceType)
    {
        var container = _db.GetContainer(databaseId: "Plotter", containerId: "Users");
        var userId = "f98f654a-f5fb-4a33-84d3-2498b8d4d348"; // jdparsons.dev@gmail.com - all of the finetuning datapoints have been added to this specific account (filter out the dedicated "TESTING" plot)
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

            var cooldownSeq = plotObj.Sequences.Where(s => s.SequenceName.ToLower() == "cooldown").FirstOrDefault();

            var cooldownHasContent = false;

            if (sequenceType == "blurb")
            {
                cooldownHasContent = !string.IsNullOrWhiteSpace(cooldownSeq.Blurb);
            }
            else if (sequenceType == "expanded summary")
            {
                cooldownHasContent = !string.IsNullOrWhiteSpace(cooldownSeq.Text);
            }
            else if (sequenceType == "full")
            {
                cooldownHasContent = !string.IsNullOrWhiteSpace(cooldownSeq.Full);
            }
            else if (sequenceType == "character")
            {
                cooldownHasContent = true; // hardcoded because character doesn't care about the sequences
            }
            else
            {
                throw new Exception($"Unknwown sequenceType: {sequenceType}");
            }


            if (plotObj.Title.ToLower().Contains("testing") == false && cooldownSeq != null && cooldownHasContent)
            {
                results.Add(plotObj);
            }
        }

        return results;
    }


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