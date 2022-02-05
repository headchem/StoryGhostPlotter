using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using StoryGhost.Models;
using System.Security.Claims;
using StoryGhost.Interfaces;

namespace StoryGhost.Generate;

public class Generate
{
    private readonly ICompletionService _completionService;

    public Generate(ICompletionService completionService)
    {
        _completionService = completionService;
    }

    [FunctionName("Generate")]
    public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] Story story, HttpRequest req, ILogger log)
    {
        var user = StaticWebAppsAuth.Parse(req);

        if (!user.IsInRole("customer")) return new UnauthorizedResult(); // even though I defined allowed roles per route in staticwebapp.config.json, I was still able to reach this point via Postman on localhost. So, I'm adding this check here just in case.

        var userId = user.FindFirst(ClaimTypes.NameIdentifier).Value;

        using (log.BeginScope(new Dictionary<string, object> { ["UserId"] = userId, ["User"] = user.Identity.Name}))
        {
            log.LogInformation("An example of an Information level message");
        }

        var result = await _completionService.GetCompletion(story);

        return new OkObjectResult(result);
    }
}
