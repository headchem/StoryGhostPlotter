using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using StoryGhost.Models;
using StoryGhost.Util;

namespace StoryGhost.Generate;

public static class GenerateLogLinePrompt
{
    [FunctionName("GenerateLogLinePrompt")]
    public static IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] GenerateLogLineProptRequest req, ILogger log)
    {
        var genre = Factory.GetGenre(req.Genre);
        var problemTemplate = Factory.GetProblemTemplate(req.ProblemTemplate);
        var heroArchetype = Factory.GetArchetype(req.HeroArchetype);
        var enemyArchetype = Factory.GetArchetype(req.EnemyArchetype);
        var primalStakes = Factory.GetPrimalStake(req.PrimalStakes);
        var dramaticQuestion = Factory.GetDramaticQuestion(req.DramaticQuestion);

        var genreContribution = genre.GetLogLineContribution(req.Seed, problemTemplate, heroArchetype, enemyArchetype, primalStakes, dramaticQuestion);
        var problemTemplateContribution = problemTemplate.GetLogLineContribution(req.Seed, genre, heroArchetype, enemyArchetype, primalStakes, dramaticQuestion);
        var heroArchetypeContribution = heroArchetype.GetHeroLogLineContribution(req.Seed, genre, problemTemplate, enemyArchetype, primalStakes, dramaticQuestion);
        var enemyArchetypeContribution = enemyArchetype.GetEnemyLogLineContribution(req.Seed, genre, problemTemplate, heroArchetype, primalStakes, dramaticQuestion);
        var primalStakesContribution = primalStakes.GetLogLineContribution(req.Seed, genre, problemTemplate, heroArchetype, enemyArchetype, dramaticQuestion);
        var dramaticQuestionContribution = dramaticQuestion.GetLogLineContribution(req.Seed, genre, problemTemplate, heroArchetype, enemyArchetype, primalStakes);

        var consolidatedContributions = $"{genreContribution} {problemTemplateContribution} The following ideas are contained in this story: {string.Join(", ", req.Keywords)}. {heroArchetypeContribution} {enemyArchetypeContribution} {primalStakesContribution} {dramaticQuestionContribution}";

        var result = new GenerateLogLinePromptResponse
        {
            Prompt = consolidatedContributions
        };

        return new OkObjectResult(result);
    }
}
