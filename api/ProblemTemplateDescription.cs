using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using StoryGhost.Util;

namespace StoryGhost.LogLineDescriptions;
public static class ProblemTemplateDescription
{
    [FunctionName("ProblemTemplateDescription")]
    public static IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req, ILogger log)
    {
        string problemTemplate = req.Query["problemTemplate"];

        var problemTemplateObj = ProblemTemplateDescriptions.GetProblemTemplateDescription(problemTemplate);

        return new OkObjectResult(problemTemplateObj);
    }
}