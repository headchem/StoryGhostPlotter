using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using StoryGhost.Util;

namespace StoryGhost.LogLineDescriptions;
public static class GenreDescription
{
    [FunctionName("GenreDescription")]
    public static IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req, ILogger log)
    {
        string genre = req.Query["genre"];

        var genreObj = GenreDescriptions.GetGenreDescription(genre);

        return new OkObjectResult(genreObj);
    }
}