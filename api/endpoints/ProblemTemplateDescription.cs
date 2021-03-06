using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using StoryGhost.Util;

namespace StoryGhost.LogLine;
public static class ProblemTemplateDescription
{
    [FunctionName("ProblemTemplateDescription")]
    public static IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "LogLine/ProblemTemplateDescription")] HttpRequest req, ILogger log)
    {
        try
        {
            var user = StaticWebAppsAuth.Parse(req);
            if (!user.IsInRole("authenticated")) return new UnauthorizedResult();

            string problemTemplate = req.Query["problemTemplate"];

            var problemTemplateObj = Factory.GetProblemTemplate(problemTemplate);

            return new OkObjectResult(problemTemplateObj);
        }
        catch (Exception ex)
        {
            log.LogError(ex.Message);
            throw ex;
        }
    }
}