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

    [FunctionName("CreateLogLineFinetuningDataset")] // NOTE: "Admin" is a reserved route by Azure Functions, so we call ours something different
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

        var finetuningRows = new List<FinetuningRow>();

        foreach (var row in rows)
        {
            var prompt = string.Join(", ", row.Genres);
            var completion = row.Overview;

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

    [FunctionName("CreateSequenceFinetuningDataset")] // NOTE: "Admin" is a reserved route by Azure Functions, so we call ours something different
    public async Task<IActionResult> CreateSequenceFinetuningDataset([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "SGAdmin/CreateSequenceFinetuningDataset")] HttpRequest req, ILogger log)
    {
        var user = StaticWebAppsAuth.Parse(req);

        if (!user.IsInRole("admin")) return new UnauthorizedResult(); // even though I defined allowed roles per route in staticwebapp.config.json, I was still able to reach this point via Postman on localhost. So, I'm adding this check here just in case.

        // try
        // {
        //     var plots = await getTrainingPlots();

        //     var results = new Dictionary<string, List<FinetuningRow>>();

        //     var sequenceNames = new List<string>{
        //         "Opening Image",
        //         "Setup",
        //         "Theme Stated",
        //         "Setup (Continued)",
        //         "Catalyst",
        //         "Debate",
        //         "Break Into Two",
        //         "Fun And Games",
        //         "First Pinch Point",
        //         "Midpoint",
        //         "Bad Guys Close In",
        //         "Second Pinch Point",
        //         "All Hope Is Lost",
        //         "Dark Night Of The Soul",
        //         "Break Into Three",
        //         "Climax",
        //         "Cooldown"
        //     };

        //     foreach (var sequenceName in sequenceNames)
        //     {
        //         results[sequenceName] = getRows(sequenceName, plots);
        //     }

        //     return new OkObjectResult(results);
        // }
        // catch (Exception ex)
        // {
        //     return new BadRequestObjectResult(ex);
        // }

        return new OkObjectResult("TODO");
    }

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