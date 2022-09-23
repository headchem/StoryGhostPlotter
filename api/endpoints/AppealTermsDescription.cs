using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using StoryGhost.Util;
using System.Collections.Generic;

namespace StoryGhost.LogLine;
public static class AppealTermsDescription
{
    [FunctionName("AppealTermsDescription")]
    public static IActionResult GetAppealTermsDescription([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "LogLine/AppealTermsDescription")] HttpRequest req, ILogger log)
    {
        try
        {
            var user = StaticWebAppsAuth.Parse(req);
            if (!user.IsInRole("authenticated")) return new UnauthorizedResult();

            var appealTerms = req.Query["appealTerms"].ToString().Split(',').ToList();

            var appealTermsObj = Factory.GetAppealTerms(appealTerms);

            return new OkObjectResult(appealTermsObj);
        }
        catch (Exception ex)
        {
            log.LogError(ex.Message);
            throw ex;
        }
    }

    [FunctionName("AppealTermsRandom")]
    public static IActionResult AppealTermsRandom([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "LogLine/AppealTermsRandom")] HttpRequest req, ILogger log)
    {
        try
        {
            var user = StaticWebAppsAuth.Parse(req);
            if (!user.IsInRole("authenticated")) return new UnauthorizedResult();

            string genresStr = req.Query["genres"];
            string numAppealTermsStr = req.Query["numAppealTerms"];
            int numAppealTerms = int.Parse(numAppealTermsStr);

            List<string> genres = new List<string>();

            if (!string.IsNullOrWhiteSpace(genresStr))
            {
                foreach (var genre in genresStr.Split(','))
                {
                    genres.Add(genre.Trim());
                }
            }

            // if no genres were passed in, select all genres, and use that to generate keywords across the entire list
            if (genres.Count == 0) {
                genres = Factory.GetGenres().Select(g => g.Name).ToList();
            }

            var appealTerms = Factory.GetRandomAppealTerms(genres, numAppealTerms);

            return new OkObjectResult(appealTerms);
        }
        catch (Exception ex)
        {
            log.LogError(ex.Message);
            throw ex;
        }
    }
}