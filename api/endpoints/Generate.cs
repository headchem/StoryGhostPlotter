using System;
using System.Collections.Generic;
using System.Linq;
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
using StoryGhost.Models.Completions;

using System.Diagnostics;
using Microsoft.ApplicationInsights;

using StoryGhost.Util;

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

            var temperature = double.Parse(req.Query["temperature"][0]);

            var result = await _completionService.GetLogLineDescriptionCompletion(userId, temperature, plot, keywordsLogitBias, false);

            var totalTokenCount = result.PromptTokenCount + result.CompletionTokenCount;

            var timespan = stopwatch.Elapsed;

            stopwatch.Stop();

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

            var result = await _completionService.GetTitles(userId, plot.Id, plot.Genres, plot.LogLineDescription, false);

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
        var temperature = double.Parse(req.Query["temperature"][0]);

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

            var result = await _completionService.GetCharacterCompletion(userId, plotId, temperature, character, false);

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

    [FunctionName("GenerateBlurb")]
    public async Task<IActionResult> GenerateBlurb([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "Sequence/GenerateBlurb")] Plot plot, HttpRequest req, ILogger log)
    {
        var user = StaticWebAppsAuth.Parse(req);
        if (!user.IsInRole("customer"))
        {
            return new OkObjectResult(new List<CompletionResponse>{
                new CompletionResponse
                {
                    Id = Guid.NewGuid().ToString(),
                    Completion = ""
                }
            });
        }

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
            var numCompletions = int.Parse(req.Query["numCompletions"][0]);
            numCompletions = Math.Min(numCompletions, 2); // don't allow more than 2 completions
            var maxTokens = 256;

            var result = await _completionService.GetBlurbCompletion(userId, targetSequence, maxTokens, temperature, plot, false, numCompletions);

            var timespan = stopwatch.Elapsed;

            stopwatch.Stop();

            //var metricsText = new Dictionary<string, string>();
            //metricsText.Add("UserId", userId);

            var promptTokenCount = result.Sum(r => r.PromptTokenCount);
            var completionTokenCount = result.Sum(r => r.CompletionTokenCount);

            var metrics = new Dictionary<string, double>();
            metrics.Add("duration in seconds", timespan.TotalMilliseconds / 1000);
            metrics.Add("token usage", promptTokenCount + completionTokenCount);

            _telemetry.TrackEvent("Completion Blurb", null, metrics);

            return new OkObjectResult(result);
        }
    }

    [FunctionName("GenerateExpandedSummary")]
    public async Task<IActionResult> GenerateExpandedSummary([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "Sequence/GenerateExpandedSummary")] Plot plot, HttpRequest req, ILogger log)
    {
        var user = StaticWebAppsAuth.Parse(req);
        if (!user.IsInRole("customer"))
        {
            return new OkObjectResult(new List<CompletionResponse>{
                new CompletionResponse
                {
                    Id = Guid.NewGuid().ToString(),
                    Completion = ""
                }
            });
        }

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
            var numCompletions = int.Parse(req.Query["numCompletions"][0]);
            numCompletions = Math.Min(numCompletions, 2); // don't allow more than 2 completions
            var maxTokens = 256;

            var result = await _completionService.GetExpandedSummaryCompletion(userId, targetSequence, maxTokens, temperature, plot, false, numCompletions);

            var timespan = stopwatch.Elapsed;

            stopwatch.Stop();

            //var metricsText = new Dictionary<string, string>();
            //metricsText.Add("UserId", userId);

            var promptTokenCount = result.Sum(r => r.PromptTokenCount);
            var completionTokenCount = result.Sum(r => r.CompletionTokenCount);

            var metrics = new Dictionary<string, double>();
            metrics.Add("duration in seconds", timespan.TotalMilliseconds / 1000);
            metrics.Add("token usage", promptTokenCount + completionTokenCount);

            _telemetry.TrackEvent("Completion Expanded Summary", null, metrics);

            return new OkObjectResult(result);
        }
    }

    [FunctionName("GenerateSceneSummary")]
    public async Task<IActionResult> GenerateSceneSummary([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "Scene/GenerateSceneSummary")] SummaryDTO dto, HttpRequest req, ILogger log)
    {
        var user = StaticWebAppsAuth.Parse(req);
        if (!user.IsInRole("customer"))
        {
            return new OkObjectResult(new List<CompletionResponse>{
                new CompletionResponse
                {
                    Id = Guid.NewGuid().ToString(),
                    Completion = ""
                }
            });
        }

        var userId = user.FindFirst(ClaimTypes.NameIdentifier).Value;

        var stopwatch = new Stopwatch();
        stopwatch.Start();

        using (log.BeginScope(new Dictionary<string, object>
        {
            ["UserId"] = userId,
            ["User"] = user.Identity.Name,
            ["PlotId"] = dto.PlotId,
        }))
        {
            var maxTokens = 192;

            var resultLowTemp = await _completionService.GetSummaryReducerCompletion(userId, dto.PlotId, dto.Full, dto.CharacterNames, maxTokens, 0.1, false, 1);
            var resultMediumTemp = await _completionService.GetSceneSummaryCompletion(userId, dto.PlotId, dto.Full, dto.CharacterNames, maxTokens, 0.35, false, 1);
            var resultHighTemp = await _completionService.GetSceneSummaryCompletion(userId, dto.PlotId, dto.Full, dto.CharacterNames, maxTokens, 0.85, false, 1);

            var timespan = stopwatch.Elapsed;

            stopwatch.Stop();

            var promptTokenCount = resultLowTemp.Sum(r => r.PromptTokenCount) + resultMediumTemp.Sum(r => r.PromptTokenCount) + resultHighTemp.Sum(r => r.PromptTokenCount);
            var completionTokenCount = resultLowTemp.Sum(r => r.CompletionTokenCount) + resultMediumTemp.Sum(r => r.CompletionTokenCount) + resultHighTemp.Sum(r => r.CompletionTokenCount);

            var metrics = new Dictionary<string, double>();
            metrics.Add("duration in seconds", timespan.TotalMilliseconds / 1000);
            metrics.Add("token usage", promptTokenCount + completionTokenCount);

            _telemetry.TrackEvent("Completion Scene Summary", null, metrics);

            var result = new List<CompletionResponse> {
                resultLowTemp[0],
                resultMediumTemp[0],
                resultHighTemp[0]
            };

            return new OkObjectResult(result);
        }
    }

    [FunctionName("GenerateSummaryReducer")]
    public async Task<IActionResult> GenerateSummaryReducer([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "Sequence/GenerateSummaryReducer")] SummaryDTO dto, HttpRequest req, ILogger log)
    {
        var user = StaticWebAppsAuth.Parse(req);
        if (!user.IsInRole("customer"))
        {
            return new OkObjectResult(new List<CompletionResponse>{
                new CompletionResponse
                {
                    Id = Guid.NewGuid().ToString(),
                    Completion = ""
                }
            });
        }

        var userId = user.FindFirst(ClaimTypes.NameIdentifier).Value;

        var stopwatch = new Stopwatch();
        stopwatch.Start();

        using (log.BeginScope(new Dictionary<string, object>
        {
            ["UserId"] = userId,
            ["User"] = user.Identity.Name,
            ["PlotId"] = dto.PlotId,
        }))
        {
            var maxTokens = 256;

            var resultLowTemp = await _completionService.GetSummaryReducerCompletion(userId, dto.PlotId, dto.Full, dto.CharacterNames, maxTokens, 0.1, false, 1);
            var resultMediumTemp = await _completionService.GetSummaryReducerCompletion(userId, dto.PlotId, dto.Full, dto.CharacterNames, maxTokens, 0.35, false, 1);
            var resultHighTemp = await _completionService.GetSummaryReducerCompletion(userId, dto.PlotId, dto.Full, dto.CharacterNames, maxTokens, 0.85, false, 1);

            var timespan = stopwatch.Elapsed;

            stopwatch.Stop();

            var promptTokenCount = resultLowTemp.Sum(r => r.PromptTokenCount) + resultMediumTemp.Sum(r => r.PromptTokenCount) + resultHighTemp.Sum(r => r.PromptTokenCount);
            var completionTokenCount = resultLowTemp.Sum(r => r.CompletionTokenCount) + resultMediumTemp.Sum(r => r.CompletionTokenCount) + resultHighTemp.Sum(r => r.CompletionTokenCount);

            var metrics = new Dictionary<string, double>();
            metrics.Add("duration in seconds", timespan.TotalMilliseconds / 1000);
            metrics.Add("token usage", promptTokenCount + completionTokenCount);

            _telemetry.TrackEvent("Completion Scene Summary", null, metrics);

            var result = new List<CompletionResponse> {
                resultLowTemp[0],
                resultMediumTemp[0],
                resultHighTemp[0]
            };

            return new OkObjectResult(result);
        }
    }


    [FunctionName("GenerateFull")]
    public async Task<IActionResult> GenerateFull([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "Sequence/GenerateFull")] Plot plot, HttpRequest req, ILogger log)
    {
        var user = StaticWebAppsAuth.Parse(req);
        if (!user.IsInRole("customer"))
        {
            return new OkObjectResult(new List<CompletionResponse>{
                new CompletionResponse
                {
                    Id = Guid.NewGuid().ToString(),
                    Completion = ""
                }
            });
        }

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
            var numCompletions = int.Parse(req.Query["numCompletions"][0]);
            numCompletions = Math.Min(numCompletions, 2); // don't allow more than 2 completions
            var maxTokens = 256;

            var result = await _completionService.GetFullCompletion(userId, targetSequence, maxTokens, temperature, plot, false, numCompletions);

            var timespan = stopwatch.Elapsed;

            stopwatch.Stop();

            //var metricsText = new Dictionary<string, string>();
            //metricsText.Add("UserId", userId);

            var promptTokenCount = result.Sum(r => r.PromptTokenCount);
            var completionTokenCount = result.Sum(r => r.CompletionTokenCount);

            var metrics = new Dictionary<string, double>();
            metrics.Add("duration in seconds", timespan.TotalMilliseconds / 1000);
            metrics.Add("token usage", promptTokenCount + completionTokenCount);

            _telemetry.TrackEvent("Completion Full", null, metrics);

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

    [FunctionName("GenerateRandomCharacter")]
    public async Task<IActionResult> GenerateRandomCharacter([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "Character/GenerateRandom")] Plot plot, HttpRequest req, ILogger log)
    {
        var user = StaticWebAppsAuth.Parse(req);
        var useTokens = user.IsInRole("customer");
        //if (!user.IsInRole("customer")) return new UnauthorizedResult();
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

            var curCharacterId = req.Query.ContainsKey("curCharacterId") ? (req.Query["curCharacterId"][0]) : "";
            var curCharacter = plot.Characters.Where(c => c.Id == curCharacterId).First();

            var (result, completionResponse) = await _completionService.GenerateCharacter(userId, plot.Id, curCharacter, plot.Characters, plot.LogLineDescription, useTokens);

            var timespan = stopwatch.Elapsed;

            stopwatch.Stop();

            var metrics = new Dictionary<string, double>();
            metrics.Add("duration in seconds", timespan.TotalMilliseconds / 1000);
            metrics.Add("token usage", completionResponse.PromptTokenCount + completionResponse.CompletionTokenCount);

            _telemetry.TrackEvent("Completion Random Character", null, metrics);

            return new OkObjectResult((result, completionResponse));
        }
    }

    [FunctionName("GenerateAllCharacters")]
    public async Task<IActionResult> GenerateAllCharacters([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "Character/GenerateAll")] Plot plot, HttpRequest req, ILogger log)
    {
        var user = StaticWebAppsAuth.Parse(req);
        var useTokens = user.IsInRole("customer");
        //if (!user.IsInRole("customer")) return new UnauthorizedResult(); // we allow non-customers to generate Characters, but they won't get the descriptions

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

            var (result, totalTokenCount) = await _completionService.GenerateAllCharacters(userId, plot.Id, plot.LogLineDescription, useTokens);

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

    [FunctionName("GetRandomSequenceList")]
    public IActionResult GetRandomSequenceList([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "Sequence/GetRandomSequenceList")] HttpRequest req, ILogger log)
    {
        var upToTargetSequenceExclusive = req.Query["upToTargetSequenceExclusive"][0];
        var sequenceNames = Factory.GetRandomSequenceList(upToTargetSequenceExclusive);

        var result = new List<UserSequence>();

        foreach (var seqName in sequenceNames)
        {
            result.Add(new UserSequence
            {
                SequenceName = seqName
            });
        }

        return new OkObjectResult(result);

    }
}