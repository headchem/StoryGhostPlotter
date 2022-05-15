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

using System.Diagnostics;
using Microsoft.ApplicationInsights;

namespace StoryGhost.Generate;

public class Generate
{
    private TelemetryClient _telemetry;
    private readonly ICompletionService _completionService;
    private readonly CosmosClient _db;

    public Generate(TelemetryClient telemetry, ICompletionService completionService, CosmosClient db)
    {
        _telemetry = telemetry;
        _completionService = completionService;
        _db = db;
    }

    [FunctionName("GenerateLogLineDescription")]
    public async Task<IActionResult> GenerateLogLineDescription([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "LogLineDescription/Generate")] Plot plot, HttpRequest req, ILogger log)
    {
        var user = StaticWebAppsAuth.Parse(req);
        if (!user.IsInRole("customer")) return new UnauthorizedResult(); // even though I defined allowed roles per route in staticwebapp.config.json, I was still able to reach this point via Postman on localhost. So, I'm adding this check here just in case.

        var userId = user.FindFirst(ClaimTypes.NameIdentifier).Value;

        var stopwatch = new Stopwatch();
        stopwatch.Start();

        using (log.BeginScope(new Dictionary<string, object>
        {
            ["UserId"] = userId,
            ["User"] = user.Identity.Name,
            ["PlotId"] = plot.Id
        }))
        {
            //log.LogInformation("An example of an Information level message");

            var keywordsLogitBias = int.Parse(req.Query["keywordsImpact"]);

            var result = await _completionService.GetLogLineDescriptionCompletion(userId, plot, keywordsLogitBias);
            var totalTokenCount = result["finetuned"].PromptTokenCount
                                + result["finetuned"].CompletionTokenCount
                                + result["keywords"].PromptTokenCount
                                + result["keywords"].CompletionTokenCount;

            // TODO: log token usage by OpenAI to current user container

            var timespan = stopwatch.Elapsed;

            stopwatch.Stop();

            //var metricsText = new Dictionary<string, string>();
            //metricsText.Add("UserId", userId);

            var metrics = new Dictionary<string, double>();
            metrics.Add("duration in seconds", timespan.TotalMilliseconds / 1000);
            metrics.Add("token usage", totalTokenCount);

            _telemetry.TrackEvent("Completion Log Line Description", null, metrics);

            return new OkObjectResult(result);
        }
    }

    [FunctionName("GenerateTitles")]
    public async Task<IActionResult> GenerateTitles([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "Titles/Generate")] Plot plot, HttpRequest req, ILogger log)
    {
        var user = StaticWebAppsAuth.Parse(req);
        if (!user.IsInRole("customer")) return new UnauthorizedResult(); // even though I defined allowed roles per route in staticwebapp.config.json, I was still able to reach this point via Postman on localhost. So, I'm adding this check here just in case.

        var userId = user.FindFirst(ClaimTypes.NameIdentifier).Value;

        var stopwatch = new Stopwatch();
        stopwatch.Start();

        using (log.BeginScope(new Dictionary<string, object>
        {
            ["UserId"] = userId,
            ["User"] = user.Identity.Name,
            ["PlotId"] = plot.Id
        }))
        {
            //log.LogInformation("An example of an Information level message");

            var result = await _completionService.GetTitles(userId, plot.Id, plot.Genres, plot.LogLineDescription);

            // TODO: log token usage by OpenAI to current user container

            var timespan = stopwatch.Elapsed;

            stopwatch.Stop();

            //var metricsText = new Dictionary<string, string>();
            //metricsText.Add("UserId", userId);

            var metrics = new Dictionary<string, double>();
            metrics.Add("duration in seconds", timespan.TotalMilliseconds / 1000);
            metrics.Add("token usage", result.CompletionResponse.PromptTokenCount + result.CompletionResponse.CompletionTokenCount);

            _telemetry.TrackEvent("Completion Titles", null, metrics);

            return new OkObjectResult(result.Titles);
        }
    }

    [FunctionName("GenerateCharacterDescription")]
    public async Task<IActionResult> GenerateCharacterDescription([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "Character/Generate")] Character character, HttpRequest req, ILogger log)
    {
        var user = StaticWebAppsAuth.Parse(req);
        if (!user.IsInRole("customer")) return new UnauthorizedResult(); // even though I defined allowed roles per route in staticwebapp.config.json, I was still able to reach this point via Postman on localhost. So, I'm adding this check here just in case.

        var userId = user.FindFirst(ClaimTypes.NameIdentifier).Value;

        var plotId = req.Query["plotId"][0];

        var stopwatch = new Stopwatch();
        stopwatch.Start();

        using (log.BeginScope(new Dictionary<string, object>
        {
            ["UserId"] = userId,
            ["User"] = user.Identity.Name,
            ["PlotId"] = plotId
        }))
        {
            //log.LogInformation("An example of an Information level message");

            var result = await _completionService.GetCharacterCompletion(userId, plotId, character);

            // TODO: log token usage by OpenAI to current user container

            var timespan = stopwatch.Elapsed;

            stopwatch.Stop();

            //var metricsText = new Dictionary<string, string>();
            //metricsText.Add("UserId", userId);

            var metrics = new Dictionary<string, double>();
            metrics.Add("duration in seconds", timespan.TotalMilliseconds / 1000);
            metrics.Add("token usage", result.PromptTokenCount + result.CompletionTokenCount);

            _telemetry.TrackEvent("Completion Character", null, metrics);

            return new OkObjectResult(result);
        }
    }

    [FunctionName("GenerateSequence")]
    public async Task<IActionResult> GenerateSequence([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "Sequence/Generate")] Plot plot, HttpRequest req, ILogger log)
    {
        var user = StaticWebAppsAuth.Parse(req);
        if (!user.IsInRole("customer")) return new UnauthorizedResult(); // even though I defined allowed roles per route in staticwebapp.config.json, I was still able to reach this point via Postman on localhost. So, I'm adding this check here just in case.

        var userId = user.FindFirst(ClaimTypes.NameIdentifier).Value;

        var stopwatch = new Stopwatch();
        stopwatch.Start();

        using (log.BeginScope(new Dictionary<string, object>
        {
            ["UserId"] = userId,
            ["User"] = user.Identity.Name,
            ["PlotId"] = plot.Id,
        }))
        {
            //log.LogInformation("An example of an Information level message");

            var targetSequence = req.Query["targetSequence"][0];
            var temperature = double.Parse(req.Query["temperature"][0]);
            var maxTokens = 256;

            var result = await _completionService.GetSequenceCompletion(userId, targetSequence, maxTokens, temperature, plot);

            // TODO: log token usage by OpenAI to current user container

            var timespan = stopwatch.Elapsed;

            stopwatch.Stop();

            //var metricsText = new Dictionary<string, string>();
            //metricsText.Add("UserId", userId);

            var metrics = new Dictionary<string, double>();
            metrics.Add("duration in seconds", timespan.TotalMilliseconds / 1000);
            metrics.Add("token usage", result.PromptTokenCount + result.CompletionTokenCount);

            _telemetry.TrackEvent("Completion Sequence", null, metrics);

            return new OkObjectResult(result);
        }
    }

    [FunctionName("GenerateAllLogLine")]
    public async Task<IActionResult> GenerateAllLogLine([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "LogLine/GenerateAll")] Plot plot, HttpRequest req, ILogger log)
    {
        var user = StaticWebAppsAuth.Parse(req);
        if (!user.IsInRole("customer")) return new UnauthorizedResult(); // even though I defined allowed roles per route in staticwebapp.config.json, I was still able to reach this point via Postman on localhost. So, I'm adding this check here just in case.

        var userId = user.FindFirst(ClaimTypes.NameIdentifier).Value;

        var stopwatch = new Stopwatch();
        stopwatch.Start();

        using (log.BeginScope(new Dictionary<string, object>
        {
            ["UserId"] = userId,
            ["User"] = user.Identity.Name,
            ["PlotId"] = plot.Id,
        }))
        {
            //log.LogInformation("An example of an Information level message");

            var (result, totalTokens) = await _completionService.GenerateAllLogLine(userId, plot.Id, plot.Genres);

            // TODO: log token usage by OpenAI to current user container

            var timespan = stopwatch.Elapsed;

            stopwatch.Stop();

            //var metricsText = new Dictionary<string, string>();
            //metricsText.Add("UserId", userId);

            var metrics = new Dictionary<string, double>();
            metrics.Add("duration in seconds", timespan.TotalMilliseconds / 1000);
            metrics.Add("token usage", totalTokens);

            _telemetry.TrackEvent("Completion Entire Log Line", null, metrics);

            return new OkObjectResult(result);
        }
    }

    [FunctionName("GenerateAllCharacters")]
    public async Task<IActionResult> GenerateAllCharacters([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "Character/GenerateAll")] Plot plot, HttpRequest req, ILogger log)
    {
        var user = StaticWebAppsAuth.Parse(req);
        if (!user.IsInRole("customer")) return new UnauthorizedResult(); // even though I defined allowed roles per route in staticwebapp.config.json, I was still able to reach this point via Postman on localhost. So, I'm adding this check here just in case.

        var userId = user.FindFirst(ClaimTypes.NameIdentifier).Value;

        var stopwatch = new Stopwatch();
        stopwatch.Start();

        using (log.BeginScope(new Dictionary<string, object>
        {
            ["UserId"] = userId,
            ["User"] = user.Identity.Name,
            ["PlotId"] = plot.Id,
        }))
        {
            //log.LogInformation("An example of an Information level message");

            var (result, totalTokenCount) = await _completionService.GenerateAllCharacters(userId, plot.Id, plot.LogLineDescription, plot.ProblemTemplate, plot.DramaticQuestion);

            // TODO: log token usage by OpenAI to current user container

            var timespan = stopwatch.Elapsed;

            stopwatch.Stop();

            //var metricsText = new Dictionary<string, string>();
            //metricsText.Add("UserId", userId);

            var metrics = new Dictionary<string, double>();
            metrics.Add("duration in seconds", timespan.TotalMilliseconds / 1000);
            metrics.Add("token usage", totalTokenCount);

            _telemetry.TrackEvent("Completion All Characters", null, metrics);

            return new OkObjectResult(result);
        }
    }


    [FunctionName("GenerateAllSequences")]
    public async Task<IActionResult> GenerateAllSequences([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "Sequence/GenerateAll")] Plot plot, HttpRequest req, ILogger log)
    {
        var user = StaticWebAppsAuth.Parse(req);
        if (!user.IsInRole("customer")) return new UnauthorizedResult(); // even though I defined allowed roles per route in staticwebapp.config.json, I was still able to reach this point via Postman on localhost. So, I'm adding this check here just in case.

        var userId = user.FindFirst(ClaimTypes.NameIdentifier).Value;

        var stopwatch = new Stopwatch();
        stopwatch.Start();

        using (log.BeginScope(new Dictionary<string, object>
        {
            ["UserId"] = userId,
            ["User"] = user.Identity.Name,
            ["PlotId"] = plot.Id,
        }))
        {
            //log.LogInformation("An example of an Information level message");

            var upToTargetSequenceExclusive = req.Query["upToTargetSequenceExclusive"][0];

            var (result, totalTokenCount) = await _completionService.GenerateAllSequences(userId, plot, upToTargetSequenceExclusive);

            // TODO: log token usage by OpenAI to current user container

            var timespan = stopwatch.Elapsed;

            stopwatch.Stop();

            //var metricsText = new Dictionary<string, string>();
            //metricsText.Add("UserId", userId);

            var metrics = new Dictionary<string, double>();
            metrics.Add("duration in seconds", timespan.TotalMilliseconds / 1000);
            metrics.Add("token usage", totalTokenCount);

            _telemetry.TrackEvent("Completion All Sequences", null, metrics);

            return new OkObjectResult(result);
        }
    }
}