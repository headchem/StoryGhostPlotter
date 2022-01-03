using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using StoryGhost.Models;
using StoryGhost.Util;

namespace StoryGhost.Generate;

public static class Generate
{
    [FunctionName("Generate")]
    public static IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] Story req, ILogger log)
    {
        var prompt = Factory.GetPrompt(req);
        
        var result = new GenerateResponse
        {
            Prompt = prompt,
            Completion = $"{req.CompletionType}_COMPLETION. "
        };

        return new OkObjectResult(result);
    }

}
