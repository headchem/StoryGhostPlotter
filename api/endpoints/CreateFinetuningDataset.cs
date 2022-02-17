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

namespace StoryGhost.Util;
public class CreateFinetuningDataset
{
    /// <summary>IMPORTANT: if this ever changes, you'll have to re-fine-tune ALL models! This is also referenced by Factory.cs</summary>
    public static string StopSequence = "\n\n###\n\n";

    private readonly CosmosClient _db;

    public CreateFinetuningDataset(CosmosClient db)
    {
        _db = db;
    }

    [FunctionName("CreateFinetuningDataset")] // NOTE: "Admin" is a reserved route by Azure Functions, so we call ours something different
    public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "SGAdmin/CreateFinetuningDataset")] HttpRequest req, ILogger log)
    {
        var user = StaticWebAppsAuth.Parse(req);

        if (!user.IsInRole("admin")) return new UnauthorizedResult(); // even though I defined allowed roles per route in staticwebapp.config.json, I was still able to reach this point via Postman on localhost. So, I'm adding this check here just in case.

        try
        {
            var plots = await getTrainingPlots();

            var results = new Dictionary<string, List<FinetuningRow>>();

            var sequenceNames = new List<string>{
                "Opening Image",
                "Setup",
                "Theme Stated",
                "Setup (Continued)",
                "Catalyst",
                "Debate",
                "Break Into Two",
                "Fun And Games",
                "First Pinch Point",
                "Midpoint",
                "Bad Guys Close In",
                "Second Pinch Point",
                "All Hope Is Lost",
                "Dark Night Of The Soul",
                "Break Into Three",
                "Climax",
                "Cooldown"
            };

            foreach (var sequenceName in sequenceNames)
            {
                results[sequenceName] = getRows(sequenceName, plots);
            }

            return new OkObjectResult(results);
        }
        catch (Exception ex)
        {
            return new BadRequestObjectResult(ex);
        }
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

    private List<FinetuningRow> getRows(string sequenceName, List<Plot> plots)
    {
        var results = new List<FinetuningRow>();

        foreach (var plot in plots)
        {
            var row = getPromptAndCompletion(sequenceName, plot);

            if (row != null)
            {
                results.Add(row);
            }
        }

        return results;
    }

    private FinetuningRow getPromptAndCompletion(string sequenceName, Plot plot)
    {
        var curSeqObj = plot.Sequences.Where(seq => seq.SequenceName == sequenceName).FirstOrDefault();

        // not all plots have all sequence types
        if (curSeqObj == null)
        {
            return null;
        }

        var row = new FinetuningRow();

        row.SequenceName = sequenceName;
        row.Prompt = Factory.GetPrompt(sequenceName, plot);

        // According to OpenAI guidelines: "Each completion should start with a whitespace due to our tokenization, which tokenizes most words with a preceding whitespace. Each completion should end with a fixed stop sequence to inform the model when the completion ends. A stop sequence could be \n, ###, or any other token that does not appear in any completion." HOWEVER, a YouTube video from OpenAI said that the preceeding space before completions wasn't needed for open-ended generation tasks.
        row.Completion = " " + curSeqObj.Text + StopSequence;

        return row;
    }
}