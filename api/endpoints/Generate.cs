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
using Microsoft.Azure.Documents;
using StoryGhost.Models.Completions;

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

    [FunctionName("GenerateLogLineDescription")]
    public async Task<IActionResult> GenerateLogLineDescription([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "LogLineDescription/Generate")] Plot plot, HttpRequest req, ILogger log)
    {
        var user = StaticWebAppsAuth.Parse(req);

        if (!user.IsInRole("customer")) return new UnauthorizedResult(); // even though I defined allowed roles per route in staticwebapp.config.json, I was still able to reach this point via Postman on localhost. So, I'm adding this check here just in case.

        var userId = user.FindFirst(ClaimTypes.NameIdentifier).Value;

        using (log.BeginScope(new Dictionary<string, object> { ["UserId"] = userId, ["User"] = user.Identity.Name }))
        {
            //log.LogInformation("An example of an Information level message");
        }

        var keywordsLogitBias = int.Parse(req.Query["keywordsImpact"]);

        var result = await _completionService.GetLogLineDescriptionCompletion(plot, keywordsLogitBias);

        // TODO: log token usage by OpenAI to current user container

        return new OkObjectResult(result);
    }

    [FunctionName("GenerateTitles")]
    public async Task<IActionResult> GenerateTitles([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "Titles/Generate")] Plot plot, HttpRequest req, ILogger log)
    {
        var user = StaticWebAppsAuth.Parse(req);

        if (!user.IsInRole("customer")) return new UnauthorizedResult(); // even though I defined allowed roles per route in staticwebapp.config.json, I was still able to reach this point via Postman on localhost. So, I'm adding this check here just in case.

        var userId = user.FindFirst(ClaimTypes.NameIdentifier).Value;

        using (log.BeginScope(new Dictionary<string, object> { ["UserId"] = userId, ["User"] = user.Identity.Name }))
        {
            //log.LogInformation("An example of an Information level message");
        }

        var result = await _completionService.GetTitles(plot.Genres, plot.LogLineDescription);

        // TODO: log token usage by OpenAI to current user container

        return new OkObjectResult(result);
    }

    [FunctionName("GenerateCharacterDescription")]
    public async Task<IActionResult> GenerateCharacterDescription([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "Character/Generate")] Character character, HttpRequest req, ILogger log)
    {
        var user = StaticWebAppsAuth.Parse(req);

        // TODO - TEMP, removing check for testing

        /*
        if (!user.IsInRole("customer")) return new UnauthorizedResult(); // even though I defined allowed roles per route in staticwebapp.config.json, I was still able to reach this point via Postman on localhost. So, I'm adding this check here just in case.

        var userId = user.FindFirst(ClaimTypes.NameIdentifier).Value;

        using (log.BeginScope(new Dictionary<string, object> { ["UserId"] = userId, ["User"] = user.Identity.Name }))
        {
            //log.LogInformation("An example of an Information level message");
        }
        */

        var result = await _completionService.GetCharacterCompletion(character);

        // TODO: log token usage by OpenAI to current user container

        return new OkObjectResult(result);
    }

    [FunctionName("GenerateSequence")]
    public async Task<IActionResult> GenerateSequence([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "Sequence/Generate")] Plot plot, HttpRequest req, ILogger log)
    {
        var user = StaticWebAppsAuth.Parse(req);

        if (!user.IsInRole("customer")) return new UnauthorizedResult(); // even though I defined allowed roles per route in staticwebapp.config.json, I was still able to reach this point via Postman on localhost. So, I'm adding this check here just in case.

        var userId = user.FindFirst(ClaimTypes.NameIdentifier).Value;

        using (log.BeginScope(new Dictionary<string, object> { ["UserId"] = userId, ["User"] = user.Identity.Name }))
        {
            //log.LogInformation("An example of an Information level message");
        }

        var targetSequence = req.Query["targetSequence"][0];
        var temperature = double.Parse(req.Query["temperature"][0]);
        var maxTokens = 256;

        var result = await _completionService.GetSequenceCompletion(targetSequence, maxTokens, temperature, plot);

        // TODO: log token usage by OpenAI to current user container

        return new OkObjectResult(result);
    }

    [FunctionName("GenerateAllSequences")]
    public async Task<IActionResult> GenerateAllSequences([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "Sequence/GenerateAll")] Plot plot, HttpRequest req, ILogger log)
    {
        var user = StaticWebAppsAuth.Parse(req);

        if (!user.IsInRole("customer")) return new UnauthorizedResult(); // even though I defined allowed roles per route in staticwebapp.config.json, I was still able to reach this point via Postman on localhost. So, I'm adding this check here just in case.

        var userId = user.FindFirst(ClaimTypes.NameIdentifier).Value;

        using (log.BeginScope(new Dictionary<string, object> { ["UserId"] = userId, ["User"] = user.Identity.Name }))
        {
            //log.LogInformation("An example of an Information level message");
        }

        var result = await _completionService.GenerateAllSequences(plot);

        // TODO: log token usage by OpenAI to current user container

        return new OkObjectResult(result);
    }

    // [FunctionName("GenerateCharacter")]
    // public async Task<IActionResult> GenerateCharacter([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "Character/Generate")] Plot plot, HttpRequest req, ILogger log)
    // {
    //     var user = StaticWebAppsAuth.Parse(req);

    //     if (!user.IsInRole("customer")) return new UnauthorizedResult(); // even though I defined allowed roles per route in staticwebapp.config.json, I was still able to reach this point via Postman on localhost. So, I'm adding this check here just in case.

    //     var userId = user.FindFirst(ClaimTypes.NameIdentifier).Value;

    //     using (log.BeginScope(new Dictionary<string, object> { ["UserId"] = userId, ["User"] = user.Identity.Name }))
    //     {
    //         //log.LogInformation("An example of an Information level message");
    //     }

    //     var archetype = req.Query["archetype"][0];

    //     var result = await _completionService.GetCharacterCompletion(archetype, plot);

    //     // TODO: log token usage by OpenAI to current user container

    //     return new OkObjectResult(result);
    // }
}