using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using StoryGhost.Util;

namespace StoryGhost.LogLine;
public static class PrimalStakesDescription
{
    [FunctionName("PrimalStakesDescription")]
    public static IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "LogLine/PrimalStakesDescription")] HttpRequest req, ILogger log)
    {
        string primalStakes = req.Query["primalStakes"];

        var primalStakesObj = Factory.GetPrimalStake(primalStakes);

        return new OkObjectResult(primalStakesObj);
    }
}