using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using StoryGhost.Util;
using StoryGhost.Models;
using StoryGhost.Interfaces;

namespace StoryGhost.LogLine;
public static class SequenceAdvice
{
    [FunctionName("SequenceAdvice")]
    public static IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "Sequence/Advice")] SequenceAdviceRequest sequenceRequest, HttpRequest req, ILogger log)
    {
        try
        {
            var user = StaticWebAppsAuth.Parse(req);
            if (!user.IsInRole("authenticated")) return new UnauthorizedResult();

            string sequenceName = req.Query["sequenceName"];

            var sequenceObj = Factory.GetSequence(sequenceName);

            if (sequenceObj == null)
            {
                return new OkObjectResult(new AdviceComponentsWrapper());
            }

            // TODO: use sequenceRequest.Text for something, maybe do emotional analysis on it, or use to render images.
            var adviceObj = Factory.GetSequenceAdvice(sequenceObj, sequenceRequest);

            return new OkObjectResult(adviceObj);
        }
        catch (Exception ex)
        {
            log.LogError(ex.Message);
            throw ex;
        }
    }
}