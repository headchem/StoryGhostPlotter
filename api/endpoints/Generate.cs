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

        var result = await _completionService.GetLogLineDescriptionCompletion(plot);

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

        var sequenceName = req.Query["sequenceName"][0];

        var result = await _completionService.GetSequenceCompletion(sequenceName, plot);

        // TODO: log token usage by OpenAI to current user container
        
        return new OkObjectResult(result);
    }

    [FunctionName("GenerateCharacter")]
    public async Task<IActionResult> GenerateCharacter([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "Character/Generate")] Plot plot, HttpRequest req, ILogger log)
    {
        var user = StaticWebAppsAuth.Parse(req);

        if (!user.IsInRole("customer")) return new UnauthorizedResult(); // even though I defined allowed roles per route in staticwebapp.config.json, I was still able to reach this point via Postman on localhost. So, I'm adding this check here just in case.

        var userId = user.FindFirst(ClaimTypes.NameIdentifier).Value;

        using (log.BeginScope(new Dictionary<string, object> { ["UserId"] = userId, ["User"] = user.Identity.Name }))
        {
            //log.LogInformation("An example of an Information level message");
        }

        var archetype = req.Query["archetype"][0];

        var result = await _completionService.GetCharacterCompletion(archetype, plot);

        // TODO: log token usage by OpenAI to current user container
        
        return new OkObjectResult(result);
    }
}