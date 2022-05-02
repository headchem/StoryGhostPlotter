using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using StoryGhost.Util;

namespace StoryGhost.LogLine;
public static class GenresDescription
{
    [FunctionName("GenresDescription")]
    public static IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "LogLine/GenresDescription")] HttpRequest req, ILogger log)
    {
        var user = StaticWebAppsAuth.Parse(req);
        if (!user.IsInRole("authenticated")) return new UnauthorizedResult();

        var genres = req.Query["genres"].ToString().Split(',').ToList();

        var genresObj = Factory.GetGenres(genres);

        return new OkObjectResult(genresObj);
    }
}