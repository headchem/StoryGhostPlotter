using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using StoryGhost.Util;

namespace StoryGhost.LogLine;
public static class GenreDescription
{
    [FunctionName("GenreDescription")]
    public static IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "LogLine/GenreDescription")] HttpRequest req, ILogger log)
    {
        string genre = req.Query["genre"];

        var genreObj = Factory.GetGenre(genre);

        return new OkObjectResult(genreObj);
    }
}