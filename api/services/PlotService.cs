using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

using StoryGhost.Interfaces;
using StoryGhost.Models;

using Microsoft.Extensions.Logging;
using Microsoft.Azure.Cosmos;
using Microsoft.ApplicationInsights;
using System.Net;


using StoryGhost.Models.Completions;

public class PlotService : IPlotService
{
    private ILogger<PlotService> _logger;
    private TelemetryClient _telemetry;
    private readonly CosmosClient _db;
    private readonly IUserService _userService;

    public PlotService(ILogger<PlotService> logger, TelemetryClient telemetry, CosmosClient db, IUserService userService)
    {
        _logger = logger;
        _telemetry = telemetry;
        _db = db;
        _userService = userService;
    }

    public async Task<Plot> CreateNewPlot(string userId, string userDisplayName, string newPlotName)
    {
        newPlotName = newPlotName.Truncate(128);

        using (_logger.BeginScope(new Dictionary<string, object> { ["UserId"] = userId, ["User"] = userDisplayName }))
        {
            // create new plot in cosmos

            var newPlot = new Plot
            {
                Id = Guid.NewGuid().ToString("N"), // formats to no dashes, all lower case
                UserId = userId,
                LogLineDescription = "",
                Title = newPlotName,
                Seed = new Random().NextInt64(),
                Keywords = new List<string>(),
                Genres = new List<string>(),
                Created = DateTime.UtcNow,
                Modified = DateTime.UtcNow,
                IsDeleted = false,
                IsPublic = false,
                Characters = new List<Character>()
            };

            var plotsContainer = _db.GetContainer(databaseId: "Plotter", containerId: "Plots");

            try
            {
                var newPlotResponse = await plotsContainer.CreateItemAsync<Plot>(newPlot, new PartitionKey(userId));
                var RUs = newPlotResponse.RequestCharge;
                //var newPlotObj = newPlotResponse.Resource;

                // update the PlotReferences field in the user's container
                await _userService.CreatePlotReference(userId, newPlot);

                _telemetry.TrackEvent("Create New Plot");

                return newPlot;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to create new plot: {userDisplayName}, userId: {userId}. Exception message: {ex.Message}");
                var deleteResult = await plotsContainer.DeleteItemAsync<Plot>(newPlot.Id, new PartitionKey(userId)); // cleanup upon failure

                throw ex;
            }
        }
    }

    public async Task<Plot> GetPlot(string userId, string plotId)
    {
        var plotContainer = _db.GetContainer(databaseId: "Plotter", containerId: "Plots");
        var plotResponse = await plotContainer.ReadItemAsync<Plot>(plotId, new PartitionKey(userId));
        var curPlotObj = plotResponse.Resource;

        return curPlotObj;
    }

    public async Task SavePlot(string userId, string plotId, Plot oldPlotObj, Plot plot)
    {
        var plotContainer = _db.GetContainer(databaseId: "Plotter", containerId: "Plots");
        var plotResponse = await plotContainer.ReadItemAsync<Plot>(plotId, new PartitionKey(userId));

        var newTitle = plot.Title;

        if (!string.IsNullOrWhiteSpace(newTitle) && newTitle != oldPlotObj.Title)
        {
            // get user container, update PlotReference to match new title

            var userContainer = _db.GetContainer(databaseId: "Plotter", containerId: "Users");
            var userResponse = await userContainer.ReadItemAsync<StoryGhost.Models.User>(userId, new PartitionKey(userId));
            var userObj = userResponse.Resource;

            userObj.PlotReferences.Where(p => p.PlotId == plotId).First().DisplayName = newTitle;

            var userPatchOps = new List<PatchOperation>();
            userPatchOps.Add(PatchOperation.Set("/plotReferences", userObj.PlotReferences));

            var userPatchResult = await userContainer.PatchItemAsync<StoryGhost.Models.User>(id: userId, partitionKey: new PartitionKey(userId), patchOperations: userPatchOps);
        }

        // update existing plot
        var plotPatchOps = new List<PatchOperation>();

        // enforce brainstorm limit on the server-side (client side has a lower number, so this is just a safeguard)
        var brainstormLimit = 30;

        if (plot.AILogLineDescriptions != null)
        {
            plot.AILogLineDescriptions = plot.AILogLineDescriptions.TakeLast(brainstormLimit).ToList();
        }

        if (plot.Characters != null)
        {
            foreach (var character in plot.Characters)
            {
                if (character.AICompletions != null)
                {
                    character.AICompletions = character.AICompletions.Take(brainstormLimit).ToList();
                }
                character.Description = character.Description.Truncate(1000);
            }
        }

        if (plot.Sequences != null)
        {
            foreach (var sequence in plot.Sequences)
            {
                if (sequence.BlurbCompletions != null)
                {
                    sequence.BlurbCompletions = sequence.BlurbCompletions.TakeLast(brainstormLimit).ToList();
                }
                sequence.Blurb = sequence.Blurb.Truncate(700);

                if (sequence.Completions != null)
                {
                    sequence.Completions = sequence.Completions.TakeLast(brainstormLimit).ToList();
                }
                sequence.Text = sequence.Text.Truncate(2000);

                if (sequence.Scenes != null)
                {
                    sequence.Scenes = sequence.Scenes.Take(50).ToList(); // max of 50 Scenes allowed per Sequence

                    foreach (var scene in sequence.Scenes)
                    {
                        if (scene.SummaryCompletions != null)
                        {
                            scene.SummaryCompletions.TakeLast(brainstormLimit).ToList();
                        }

                        if (scene.FullCompletions != null)
                        {
                            scene.FullCompletions.TakeLast(brainstormLimit).ToList();
                        }

                        // TODO: are these the right limit values?
                        scene.Summary = scene.Summary.Truncate(10000);
                        scene.Full = scene.Full.Truncate(50000);
                    }
                }
            }
        }

        if (plot.AITitles != null)
        {
            plot.AITitles = plot.AITitles.Take(brainstormLimit).ToList();
        }

        if (plot.Characters != null)
        {
            plot.Characters = plot.Characters.Take(brainstormLimit).ToList();
        }

        if (plot.Keywords != null)
        {
            plot.Keywords = plot.Keywords.Take(10).ToList();
        }

        if (plot.Sequences != null)
        {
            plot.Sequences = plot.Sequences.Take(brainstormLimit).ToList(); // safeguard, isn't possible via UI alone
        }

        var newLogLineDescription = plot.LogLineDescription.Truncate(1000);
        var newAILogLineDescriptions = plot.AILogLineDescriptions;
        var newAITitles = plot.AITitles;
        var newCharacters = plot.Characters;
        var newDramaticQuestion = plot.DramaticQuestion;
        var newGenres = plot.Genres;
        var newKeywords = plot.Keywords;
        var newProblemTemplate = plot.ProblemTemplate;
        var newSequences = plot.Sequences;
        var newIsPublic = plot.IsPublic;

        if (!string.IsNullOrWhiteSpace(newLogLineDescription) && newLogLineDescription != oldPlotObj.LogLineDescription)
        {
            plotPatchOps.Add(PatchOperation.Set("/logLineDescription", newLogLineDescription));
        }

        if (!string.IsNullOrWhiteSpace(newTitle) && newTitle != oldPlotObj.Title)
        {
            plotPatchOps.Add(PatchOperation.Set("/title", newTitle));
        }

        if (!string.IsNullOrWhiteSpace(newDramaticQuestion) && newDramaticQuestion != oldPlotObj.DramaticQuestion)
        {
            plotPatchOps.Add(PatchOperation.Set("/dramaticQuestion", newDramaticQuestion));
        }

        if (newGenres != null && string.Join(',', newGenres) != string.Join(',', oldPlotObj.Genres ?? new List<string>()))
        {
            plotPatchOps.Add(PatchOperation.Set("/genres", newGenres));
        }

        if (newAITitles != null && string.Join(',', newAITitles) != string.Join(',', oldPlotObj.AITitles ?? new List<string>()))
        {
            plotPatchOps.Add(PatchOperation.Set("/AITitles", newAITitles));
        }

        // if keywords exists on both ends, update it
        if (newKeywords != null && oldPlotObj.Keywords != null && string.Join(',', newKeywords) != string.Join(',', oldPlotObj.Keywords))
        {
            plotPatchOps.Add(PatchOperation.Set("/keywords", newKeywords));
        }

        if (!string.IsNullOrWhiteSpace(newProblemTemplate) && newProblemTemplate != oldPlotObj.ProblemTemplate)
        {
            plotPatchOps.Add(PatchOperation.Set("/problemTemplate", newProblemTemplate));
        }

        if (newIsPublic != oldPlotObj.IsPublic)
        {
            plotPatchOps.Add(PatchOperation.Set("/isPublic", newIsPublic));
        }

        var aiCompletionsComparer = new ObjectsComparer.Comparer<List<CompletionResponse>>();
        if (aiCompletionsComparer.Compare(newAILogLineDescriptions, oldPlotObj.AILogLineDescriptions) == false)
        {
            plotPatchOps.Add(PatchOperation.Set("/AILogLineDescriptions", newAILogLineDescriptions));
        }

        var seqComparer = new ObjectsComparer.Comparer<List<UserSequence>>();
        if (seqComparer.Compare(newSequences, oldPlotObj.Sequences) == false)
        {
            plotPatchOps.Add(PatchOperation.Set("/sequences", newSequences));
        }

        var characterComparer = new ObjectsComparer.Comparer<List<Character>>();
        if (characterComparer.Compare(newCharacters, oldPlotObj.Characters) == false)
        {
            plotPatchOps.Add(PatchOperation.Set("/characters", newCharacters));
        }

        if (plotPatchOps.Count > 0)
        {
            plotPatchOps.Add(PatchOperation.Set("/modified", DateTime.UtcNow));
            var plotPatchResult = await plotContainer.PatchItemAsync<Plot>(id: plotId, partitionKey: new PartitionKey(userId), patchOperations: plotPatchOps);
        }
    }

    public async Task DeletePlot(string userId, string plotId)
    {
        var plotPatchOps = new List<PatchOperation>();
        plotPatchOps.Add(PatchOperation.Set("/isDeleted", true));

        plotPatchOps.Add(PatchOperation.Set("/modified", DateTime.UtcNow));

        var plotContainer = _db.GetContainer(databaseId: "Plotter", containerId: "Plots");
        var plotResponse = await plotContainer.ReadItemAsync<Plot>(plotId, new PartitionKey(userId));

        var plotPatchResult = await plotContainer.PatchItemAsync<Plot>(id: plotId, partitionKey: new PartitionKey(userId), patchOperations: plotPatchOps);

        _telemetry.TrackEvent("Delete Plot");
    }

    public async Task LogTokenUsage(string userId, string plotId, long tokensUsed)
    {
        var plotPatchOps = new List<PatchOperation>();

        plotPatchOps.Add(PatchOperation.Increment("/tokensUsed", tokensUsed));

        plotPatchOps.Add(PatchOperation.Set("/modified", DateTime.UtcNow));

        var plotContainer = _db.GetContainer(databaseId: "Plotter", containerId: "Plots");
        var plotResponse = await plotContainer.ReadItemAsync<Plot>(plotId, new PartitionKey(userId));

        var plotPatchResult = await plotContainer.PatchItemAsync<Plot>(id: plotId, partitionKey: new PartitionKey(userId), patchOperations: plotPatchOps);

        // we already log tokens in Generate.cs
        // var teleDict = new Dictionary<string, string>
        // {
        //     ["UserId"] = userId,
        //     //["User"] = userDisplayName
        // };

        // _telemetry.TrackMetric("Tokens Used", tokensUsed, teleDict);
    }

}