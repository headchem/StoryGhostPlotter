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
public static class DramaticQuestionDescription
{
    [FunctionName("DramaticQuestionDescription")]
    public static IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "LogLine/DramaticQuestionDescription")] HttpRequest req, ILogger log)
    {
        var user = StaticWebAppsAuth.Parse(req);
        if (!user.IsInRole("authenticated")) return new UnauthorizedResult();

        string dramaticQuestion = req.Query["dramaticQuestion"];

        var dramaticQuestionObj = Factory.GetDramaticQuestion(dramaticQuestion);

        return new OkObjectResult(dramaticQuestionObj);
    }
}
