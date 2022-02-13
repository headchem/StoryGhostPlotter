using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using Microsoft.Azure.Cosmos;
using System.Collections.Generic;
using System.Net;
using System.Linq;
using Newtonsoft.Json;
using StoryGhost.Util;
using StoryGhost.Models;



namespace StoryGhost.LogLine;
public class UserActions
{
    private readonly CosmosClient _db;

    public UserActions(CosmosClient db)
    {
        _db = db;
    }

    /// <summary>
    /// Ensure current user is logged in, then check if a Cosmos container exists for them. If a container exists, return it, otherwise create a new container.
    /// </summary>
    [FunctionName("User")]
    public async Task<IActionResult> GetUser([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "User")] HttpRequest req, ILogger log)
    {
        var user = StaticWebAppsAuth.Parse(req);
        if (user.Identity == null || !user.Identity.IsAuthenticated) return new UnauthorizedResult();

        //if (!user.IsInRole("customer")) return new UnauthorizedResult(); // even though I defined allowed roles per route in staticwebapp.config.json, I was still able to reach this point via Postman on localhost. So, I'm adding this check here just in case.

        var userId = user.FindFirst(ClaimTypes.NameIdentifier).Value;

        using (log.BeginScope(new Dictionary<string, object> { ["UserId"] = userId, ["User"] = user.Identity.Name }))
        {
            //log.LogInformation("An example of an Information level message");

            // Read the item to see if it exists.
            var container = _db.GetContainer(databaseId: "Plotter", containerId: "Users");

            try
            {
                var userResponse = await container.ReadItemAsync<StoryGhost.Models.User>(userId, new PartitionKey(userId)); //await _db.ReadItemAsync<TestUser>(u.Id, new PartitionKey(u.UserId));
                var RUs = userResponse.RequestCharge;
                var existingUserObj = userResponse.Resource;

                // filter out plots flagged as deleted
                existingUserObj.PlotReferences = existingUserObj.PlotReferences.Where(p => p.IsDeleted == false).ToList();

                return new OkObjectResult(existingUserObj);
            }
            catch (CosmosException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                var newUser = new StoryGhost.Models.User
                {
                    Id = userId,
                    DisplayName = user.Identity.Name,
                    Created = DateTime.UtcNow,
                    Modified = DateTime.UtcNow
                };

                try
                {
                    var newUserResponse = await container.CreateItemAsync<StoryGhost.Models.User>(newUser, new PartitionKey(newUser.Id));
                    var RUs = newUserResponse.RequestCharge;

                    return new OkObjectResult(newUser);
                }
                catch (Exception exNewUser)
                {
                    log.LogError($"Failed to create new user: {user.Identity.Name}, userId: {userId}. Exception message: {exNewUser.Message}");
                    throw exNewUser;
                }
            }
        }

        throw new Exception("Unable to retrieve user");
    }

    [FunctionName("NewPlot")]
    public async Task<IActionResult> NewPlot([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "NewPlot")] string NewPlotName, HttpRequest req, ILogger log)
    {
        var user = StaticWebAppsAuth.Parse(req);
        if (user.Identity == null || !user.Identity.IsAuthenticated) return new UnauthorizedResult();
        var userId = user.FindFirst(ClaimTypes.NameIdentifier).Value;

        using (log.BeginScope(new Dictionary<string, object> { ["UserId"] = userId, ["User"] = user.Identity.Name }))
        {
            // create new plot in cosmos

            var newPlot = new Plot
            {
                Id = Guid.NewGuid().ToString("N"), // formats to no dashes, all lower case
                UserId = userId,
                Title = NewPlotName,
                Seed = new Random().NextInt64(),
                Keywords = new List<string>(),
                Created = DateTime.UtcNow,
                Modified = DateTime.UtcNow,
                IsDeleted = false
            };

            var plotsContainer = _db.GetContainer(databaseId: "Plotter", containerId: "Plots");

            try
            {
                var newPlotResponse = await plotsContainer.CreateItemAsync<Plot>(newPlot, new PartitionKey(userId));
                var RUs = newPlotResponse.RequestCharge;
                //var newPlotObj = newPlotResponse.Resource;

                // update the PlotReferences field in the user's container
                var userContainer = _db.GetContainer(databaseId: "Plotter", containerId: "Users");
                var userResponse = await userContainer.ReadItemAsync<StoryGhost.Models.User>(userId, new PartitionKey(userId));
                var userObj = userResponse.Resource;

                if (userObj.PlotReferences == null)
                {
                    userObj.PlotReferences = new List<PlotReference>();
                }

                userObj.PlotReferences.Add(new PlotReference
                {
                    PlotId = newPlot.Id,
                    DisplayName = NewPlotName,
                    IsDeleted = false
                });

                var patchOps = new List<PatchOperation>();
                patchOps.Add(PatchOperation.Set("/plotReferences", userObj.PlotReferences));
                patchOps.Add(PatchOperation.Set("/modified", DateTime.UtcNow));

                var patchResult = await userContainer.PatchItemAsync<StoryGhost.Models.User>(id: userId, partitionKey: new PartitionKey(userId), patchOperations: patchOps);

                return new OkObjectResult(newPlot.Id);
            }
            catch (Exception ex)
            {
                log.LogError($"Failed to create new plot: {user.Identity.Name}, userId: {userId}. Exception message: {ex.Message}");
                var deleteResult = await plotsContainer.DeleteItemAsync<Plot>(newPlot.Id, new PartitionKey(userId)); // cleanup upon failure

                throw ex;
            }
        }
    }

    [FunctionName("GetPlot")]
    public async Task<IActionResult> GetPlot([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "GetPlot")] HttpRequest req, ILogger log)
    {
        var user = StaticWebAppsAuth.Parse(req);
        if (user.Identity == null || !user.Identity.IsAuthenticated) return new UnauthorizedResult();
        var userId = user.FindFirst(ClaimTypes.NameIdentifier).Value;
        var plotId = req.Query["id"][0];

        var plotContainer = _db.GetContainer(databaseId: "Plotter", containerId: "Plots");
        var plotResponse = await plotContainer.ReadItemAsync<Plot>(plotId, new PartitionKey(userId));
        var plotObj = plotResponse.Resource;

        if (plotObj.IsDeleted) return new NotFoundResult();

        if (plotObj.UserId != userId) return new UnauthorizedResult();

        return new OkObjectResult(plotObj);
    }

    [FunctionName("SaveLogLine")]
    public async Task<IActionResult> SaveLogLine([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "SaveLogLine")] Plot plot, HttpRequest req, ILogger log)
    {
        var user = StaticWebAppsAuth.Parse(req);
        if (user.Identity == null || !user.Identity.IsAuthenticated) return new UnauthorizedResult();
        var userId = user.FindFirst(ClaimTypes.NameIdentifier).Value;

        var plotId = req.Query["id"][0];

        var plotContainer = _db.GetContainer(databaseId: "Plotter", containerId: "Plots");
        var plotResponse = await plotContainer.ReadItemAsync<Plot>(plotId, new PartitionKey(userId));
        var curPlotObj = plotResponse.Resource;

        if (curPlotObj.UserId != userId) return new UnauthorizedResult();

        var newTitle = plot.Title;

        if (!string.IsNullOrWhiteSpace(newTitle) && newTitle != curPlotObj.Title)
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

        var newDramaticQuestion = plot.DramaticQuestion;
        var newEnemyArchetype = plot.EnemyArchetype;
        var newGenre = plot.Genre;
        var newHeroArchetype = plot.HeroArchetype;
        var newKeywords = plot.Keywords;
        var newPrimalStakes = plot.PrimalStakes;
        var newProblemTemplate = plot.ProblemTemplate;
        var newSequences = plot.Sequences;

        if (!string.IsNullOrWhiteSpace(newTitle) && newTitle != curPlotObj.Title)
        {
            plotPatchOps.Add(PatchOperation.Set("/title", newTitle));
        }

        if (!string.IsNullOrWhiteSpace(newDramaticQuestion) && newDramaticQuestion != curPlotObj.DramaticQuestion)
        {
            plotPatchOps.Add(PatchOperation.Set("/dramaticQuestion", newDramaticQuestion));
        }

        if (!string.IsNullOrWhiteSpace(newEnemyArchetype) && newEnemyArchetype != curPlotObj.EnemyArchetype)
        {
            plotPatchOps.Add(PatchOperation.Set("/enemyArchetype", newEnemyArchetype));
        }

        if (!string.IsNullOrWhiteSpace(newGenre) && newGenre != curPlotObj.Genre)
        {
            plotPatchOps.Add(PatchOperation.Set("/genre", newGenre));
        }

        if (!string.IsNullOrWhiteSpace(newHeroArchetype) && newHeroArchetype != curPlotObj.HeroArchetype)
        {
            plotPatchOps.Add(PatchOperation.Set("/heroArchetype", newHeroArchetype));
        }

        // if keywords exists on both ends, update it
        if (newKeywords != null && curPlotObj.Keywords != null && string.Join(',', newKeywords) != string.Join(',', curPlotObj.Keywords))
        {
            plotPatchOps.Add(PatchOperation.Set("/keywords", newKeywords));
        }

        if (!string.IsNullOrWhiteSpace(newPrimalStakes) && newPrimalStakes != curPlotObj.PrimalStakes)
        {
            plotPatchOps.Add(PatchOperation.Set("/primalStakes", newPrimalStakes));
        }

        if (!string.IsNullOrWhiteSpace(newProblemTemplate) && newProblemTemplate != curPlotObj.ProblemTemplate)
        {
            plotPatchOps.Add(PatchOperation.Set("/problemTemplate", newProblemTemplate));
        }

        var seqComparer = new ObjectsComparer.Comparer<List<UserSequence>>();

        if (seqComparer.Compare(newSequences, curPlotObj.Sequences) == false)
        {
            plotPatchOps.Add(PatchOperation.Set("/sequences", newSequences));
        }

        if (plotPatchOps.Count > 0)
        {
            plotPatchOps.Add(PatchOperation.Set("/modified", DateTime.UtcNow));
            var plotPatchResult = await plotContainer.PatchItemAsync<Plot>(id: plotId, partitionKey: new PartitionKey(userId), patchOperations: plotPatchOps);
        }

        return new NoContentResult();
    }

    [FunctionName("DeletePlot")]
    public async Task<IActionResult> DeletePlot([HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "DeletePlot")] HttpRequest req, ILogger log)
    {
        var user = StaticWebAppsAuth.Parse(req);
        if (user.Identity == null || !user.Identity.IsAuthenticated) return new UnauthorizedResult();
        var userId = user.FindFirst(ClaimTypes.NameIdentifier).Value;

        var plotId = req.Query["id"][0];

        var plotContainer = _db.GetContainer(databaseId: "Plotter", containerId: "Plots");
        var plotResponse = await plotContainer.ReadItemAsync<Plot>(plotId, new PartitionKey(userId));
        var curPlotObj = plotResponse.Resource;

        if (curPlotObj.IsDeleted) return new NotFoundResult();

        if (curPlotObj.UserId != userId) return new UnauthorizedResult();

        // update IsDeleted to true in both the Plot item and the User.PlotReferences item

        var userContainer = _db.GetContainer(databaseId: "Plotter", containerId: "Users");
        var userResponse = await userContainer.ReadItemAsync<StoryGhost.Models.User>(userId, new PartitionKey(userId));
        var userObj = userResponse.Resource;

        userObj.PlotReferences.Where(p => p.PlotId == plotId).First().IsDeleted = true;

        var userPatchOps = new List<PatchOperation>();
        userPatchOps.Add(PatchOperation.Set("/plotReferences", userObj.PlotReferences));

        var userPatchResult = await userContainer.PatchItemAsync<StoryGhost.Models.User>(id: userId, partitionKey: new PartitionKey(userId), patchOperations: userPatchOps);


        var plotPatchOps = new List<PatchOperation>();
        plotPatchOps.Add(PatchOperation.Set("/isDeleted", true));

        plotPatchOps.Add(PatchOperation.Set("/modified", DateTime.UtcNow));
        var plotPatchResult = await plotContainer.PatchItemAsync<Plot>(id: plotId, partitionKey: new PartitionKey(userId), patchOperations: plotPatchOps);

        return new NoContentResult();
    }

}