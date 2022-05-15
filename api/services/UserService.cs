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


namespace StoryGhost.Services;

public class UserService : IUserService
{

    private ILogger<UserService> _logger;
    private TelemetryClient _telemetry;
    private readonly CosmosClient _db;

    public UserService(ILogger<UserService> logger, TelemetryClient telemetry, CosmosClient db)
    {
        _logger = logger;
        _telemetry = telemetry;
        _db = db;
    }

    public async Task<StoryGhost.Models.User> GetOrCreateUser(string userId, string displayName)
    {
        using (_logger.BeginScope(new Dictionary<string, object> { ["UserId"] = userId, ["User"] = displayName }))
        {
            //log.LogInformation("An example of an Information level message");

            // Read the item to see if it exists.
            var container = _db.GetContainer(databaseId: "Plotter", containerId: "Users");

            try
            {
                var userResponse = await container.ReadItemAsync<StoryGhost.Models.User>(userId, new PartitionKey(userId));
                var RUs = userResponse.RequestCharge;
                var existingUserObj = userResponse.Resource;

                // filter out plots flagged as deleted
                if (existingUserObj.PlotReferences != null)
                {
                    existingUserObj.PlotReferences = existingUserObj.PlotReferences.Where(p => p.IsDeleted == false).ToList();
                }

                return existingUserObj;
            }
            catch (CosmosException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                var newUser = new StoryGhost.Models.User
                {
                    Id = userId,
                    DisplayName = displayName,
                    Created = DateTime.UtcNow,
                    Modified = DateTime.UtcNow
                };

                try
                {
                    var newUserResponse = await container.CreateItemAsync<StoryGhost.Models.User>(newUser, new PartitionKey(newUser.Id));
                    var RUs = newUserResponse.RequestCharge;

                    _telemetry.TrackEvent("Create New User");

                    return newUser;
                }
                catch (Exception exNewUser)
                {
                    _logger.LogError($"Failed to create new user: {displayName}, userId: {userId}. Exception message: {exNewUser.Message}");
                    throw exNewUser;
                }
            }
        }

        throw new Exception("Unable to retrieve user");
    }

    public async Task CreatePlotReference(string userId, Plot newPlot)
    {
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
            DisplayName = newPlot.Title,
            IsDeleted = false
        });

        var patchOps = new List<PatchOperation>();
        patchOps.Add(PatchOperation.Set("/plotReferences", userObj.PlotReferences));
        patchOps.Add(PatchOperation.Set("/modified", DateTime.UtcNow));

        var patchResult = await userContainer.PatchItemAsync<StoryGhost.Models.User>(id: userId, partitionKey: new PartitionKey(userId), patchOperations: patchOps);
    }

    public async Task DeletePlotReference(string userId, string plotId)
    {
        var userContainer = _db.GetContainer(databaseId: "Plotter", containerId: "Users");
        var userResponse = await userContainer.ReadItemAsync<StoryGhost.Models.User>(userId, new PartitionKey(userId));
        var userObj = userResponse.Resource;

        userObj.PlotReferences.Where(p => p.PlotId == plotId).First().IsDeleted = true;

        var userPatchOps = new List<PatchOperation>();
        userPatchOps.Add(PatchOperation.Set("/plotReferences", userObj.PlotReferences));

        var userPatchResult = await userContainer.PatchItemAsync<StoryGhost.Models.User>(id: userId, partitionKey: new PartitionKey(userId), patchOperations: userPatchOps);
    }

    public async Task<int> GetTokensRemaining(string userId) {
        var userContainer = _db.GetContainer(databaseId: "Plotter", containerId: "Users");
        var userResponse = await userContainer.ReadItemAsync<StoryGhost.Models.User>(userId, new PartitionKey(userId));
        var userObj = userResponse.Resource;

        return userObj.TokensRemaining;
    }

    public async Task AddTokens(string userId, int numTokens)
    {
        var userContainer = _db.GetContainer(databaseId: "Plotter", containerId: "Users");
        var userResponse = await userContainer.ReadItemAsync<StoryGhost.Models.User>(userId, new PartitionKey(userId));
        var userObj = userResponse.Resource;

        var curTokens = userObj.TokensRemaining;
        curTokens = Math.Max(0, curTokens); // if adding new tokens, ensure we start at 0, even if user went negative from a "Genenate All" call

        var newTokens = curTokens + numTokens;

        var patchOps = new List<PatchOperation>();
        patchOps.Add(PatchOperation.Set("/tokensRemaining", newTokens));
        patchOps.Add(PatchOperation.Set("/modified", DateTime.UtcNow));

        var patchResult = await userContainer.PatchItemAsync<StoryGhost.Models.User>(id: userId, partitionKey: new PartitionKey(userId), patchOperations: patchOps);
    }

    public async Task DeductTokens(string userId, int numTokens)
    {
        var userContainer = _db.GetContainer(databaseId: "Plotter", containerId: "Users");
        var userResponse = await userContainer.ReadItemAsync<StoryGhost.Models.User>(userId, new PartitionKey(userId));
        var userObj = userResponse.Resource;

        var newTokens = userObj.TokensRemaining - numTokens;
        // we allow negative tokens in cases where the user was low on tokens and execute a "Generate All" method. There is a check elsewhere for extremely negative balances as a safeguard.

        var patchOps = new List<PatchOperation>();
        patchOps.Add(PatchOperation.Set("/tokensRemaining", newTokens));
        patchOps.Add(PatchOperation.Set("/modified", DateTime.UtcNow));

        var patchResult = await userContainer.PatchItemAsync<StoryGhost.Models.User>(id: userId, partitionKey: new PartitionKey(userId), patchOperations: patchOps);
    }
}