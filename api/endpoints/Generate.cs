using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using Microsoft.Azure.Cosmos;
using StoryGhost.Models;
using StoryGhost.Interfaces;
using System.Net;
using Newtonsoft.Json;

namespace StoryGhost.Generate;

public class Generate
{
    private readonly ICompletionService _completionService;
    private readonly CosmosClient _db;

    public Generate(ICompletionService completionService, CosmosClient db)
    {
        _completionService = completionService;
        _db = db;
    }

    [FunctionName("Generate")]
    public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] Story story, HttpRequest req, ILogger log)
    {
        var user = StaticWebAppsAuth.Parse(req);

        if (!user.IsInRole("customer")) return new UnauthorizedResult(); // even though I defined allowed roles per route in staticwebapp.config.json, I was still able to reach this point via Postman on localhost. So, I'm adding this check here just in case.

        var userId = user.FindFirst(ClaimTypes.NameIdentifier).Value;

        using (log.BeginScope(new Dictionary<string, object> { ["UserId"] = userId, ["User"] = user.Identity.Name }))
        {
            log.LogInformation("An example of an Information level message");
        }

        var result = await _completionService.GetCompletion(story);

        // testing Cosmos db
        // Read the item to see if it exists.
        var container = _db.GetContainer("Plotter", "Users");

        try
        {
            var testUserResponse = await container.ReadItemAsync<TestUser>(userId, new PartitionKey(userId)); //await _db.ReadItemAsync<TestUser>(u.Id, new PartitionKey(u.UserId));
        }
        catch (CosmosException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
        {
            var newUser = new TestUser
            {
                Id = userId,
                DisplayName = user.Identity.Name
            };

            var newUserResponse = await container.CreateItemAsync<TestUser>(newUser, new PartitionKey(newUser.Id));
        }

        return new OkObjectResult(result);
    }
}

public class TestUser
{
    [JsonProperty(PropertyName = "id")]
    public string Id { get; set; } // the User Id from authentication
    public string DisplayName { get; set; }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}