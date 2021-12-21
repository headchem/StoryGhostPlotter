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

namespace StoryGhost.LogLineDescriptions;
public static class DramaticQuestionDescription
{
    [FunctionName("DramaticQuestionDescription")]
    public static IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req, ILogger log)
    {
        string dramaticQuestion = req.Query["dramaticQuestion"];

        var dramaticQuestionObj = DramaticQuestionDescriptions.GetDramaticQuestionDescription(dramaticQuestion);

        return new OkObjectResult(dramaticQuestionObj);
    }
}
