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

namespace StoryGhost.LogLine;
public static class LogLineOptions
{
    [FunctionName("LogLineOptions")]
    public static IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "LogLine/LogLineOptions")] HttpRequest req, ILogger log)
    {
        try
        {
            var user = StaticWebAppsAuth.Parse(req);
            if (!user.IsInRole("authenticated")) return new UnauthorizedResult();

            // key=dropdown type (like "genres", or "archetypes")
            // value=tuple of strings where ("id", "display name")
            var options = new Dictionary<string, List<(string, string, List<string>, List<string>, string)>>();

            var genres = Factory.GetGenres();
            var genresOptions = genres.Select(x => (x.Id, x.Name, new List<string>(), new List<string>(), x.Description)).OrderBy(x => x.Name).ToList();
            options.Add("genres", genresOptions);

            var appealTerms = Factory.GetAppealTerms();
            var appealTermsOptions = appealTerms.Select(x => (x.Id, x.Name, x.Genres, x.Categories, x.Description)).OrderBy(x => x.Name).ToList();
            options.Add("appealTerms", appealTermsOptions);

            var problemTemplates = Factory.GetProblemTemplates();
            var problemTemplatesOptions = problemTemplates.Select(x => (x.Id, x.Name, new List<string>(), new List<string>(), "")).OrderBy(x => x.Name).ToList();
            options.Add("problemTemplates", problemTemplatesOptions);

            var archetypes = Factory.GetArchetypes();
            var archetypesOptions = archetypes.Select(a => (a.Id, a.Name, new List<string>(), new List<string>(), "")).OrderBy(x => x.Name).ToList();
            options.Add("archetypes", archetypesOptions);

            var dramaticQuestions = Factory.GetDramaticQuestions();
            var dramaticQuestionsOptions = dramaticQuestions.Select(x => (x.Id, x.Name, new List<string>(), new List<string>(), "")).OrderBy(x => x.Name).ToList();
            options.Add("dramaticQuestions", dramaticQuestionsOptions);

            var emotions = Factory.GetEmotions();
            var emotionsOptions = emotions.Select(x => (x.Id, $"{x.Name} ({string.Join(", ", x.Synonyms)})", new List<string>(), new List<string>(), "")).OrderBy(x => x.Item2).ToList();
            options.Add("emotionDescriptions", emotionsOptions);

            return new OkObjectResult(options);
        }
        catch (Exception ex)
        {
            log.LogError(ex.Message);
            throw ex;
        }
    }
}
