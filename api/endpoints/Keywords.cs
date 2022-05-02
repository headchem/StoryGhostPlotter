using System;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using StoryGhost.Util;
using StoryGhost.Interfaces;

namespace StoryGhost.LogLine;
public class Keywords
{
    private readonly IKeywordsService _keywordsService;

    public Keywords(IKeywordsService keywordsService)
    {
        _keywordsService = keywordsService;
    }

    [FunctionName("Keywords")]
    public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "Keywords")] HttpRequest req, ILogger log)
    {
        var user = StaticWebAppsAuth.Parse(req);
        if (!user.IsInRole("authenticated")) return new UnauthorizedResult();

        string genresStr = req.Query["genres"];
        string numKeywordsStr = req.Query["numKeywords"];
        int numKeywords = int.Parse(numKeywordsStr);

        List<string> genres = new List<string>();

        foreach (var genre in genresStr.Split(','))
        {
            genres.Add(genre.Trim());
        }

        var keywords = _keywordsService.GetKeywords(genres, numKeywords);

        return new OkObjectResult(keywords);
    }
}
