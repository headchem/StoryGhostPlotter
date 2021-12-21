using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace StoryGhost.Generate;

public static class GenerateLogLinePrompt
{
    [FunctionName("GenerateLogLinePrompt")]
    public static IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req, ILogger log)
    {
        string setting = req.Query["setting"];

        string responseMessage = $"this is the GPT-3 prompt with the following inputs: setting: {setting}";

        return new OkObjectResult(responseMessage);
    }
}
