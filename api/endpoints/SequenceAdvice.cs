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
        string sequenceName = req.Query["sequenceName"];

        var sequenceObj = Factory.GetSequence(sequenceName);

        // TODO: use sequenceRequest.Text for something, maybe do emotional analysis on it, or use to render images.

        var adviceObj = sequenceObj.GetAdvice(sequenceRequest.Genres, sequenceRequest.ProblemTemplate, sequenceRequest.HeroArchetype, sequenceRequest.DramaticQuestion);

        return new OkObjectResult(adviceObj);
    }
}