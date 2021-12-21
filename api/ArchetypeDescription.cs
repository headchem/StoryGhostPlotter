using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using StoryGhost.Util;

namespace StoryGhost.LogLineDescriptions;
public static class ArchetypeDescription
{
    [FunctionName("ArchetypeDescription")]
    public static IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req, ILogger log)
    {
        string archetype = req.Query["archetype"];

        var archetypeObj = ArchetypeDescriptions.GetArchetypeDescription(archetype);

        return new OkObjectResult(archetypeObj);
    }
}