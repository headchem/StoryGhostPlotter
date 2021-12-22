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

        var genreContribution = genre.GetLogLineContribution(problemTemplate, heroArchetype, enemyArchetype, primalStakes, dramaticQuestion);
        var problemTemplateContribution = problemTemplate.GetLogLineContribution(genre, heroArchetype, enemyArchetype, primalStakes, dramaticQuestion);
        var heroArchetypeContribution = heroArchetype.GetHeroLogLineContribution(genre, problemTemplate, enemyArchetype, primalStakes, dramaticQuestion);
        var enemyArchetypeContribution = enemyArchetype.GetEnemyLogLineContribution(genre, problemTemplate, heroArchetype, primalStakes, dramaticQuestion);
        var primalStakesContribution = primalStakes.GetLogLineContribution(genre, problemTemplate, heroArchetype, enemyArchetype, dramaticQuestion);
        var dramaticQuestionContribution = dramaticQuestion.GetLogLineContribution(genre, problemTemplate, heroArchetype, enemyArchetype, primalStakes);

        var consolidatedContributions = $"{genreContribution}. {problemTemplateContribution}. {heroArchetypeContribution}. {enemyArchetypeContribution}. {primalStakesContribution}. {dramaticQuestionContribution}";

        var result = new GenerateLogLinePromptResponse{
            Prompt = $"this is the GPT-3 prompt with the following inputs: genre: {req.Genre}, problem template: {req.ProblemTemplate}, keywords: {string.Join("; ", req.Keywords)}, hero archetype: {req.HeroArchetype}, enemy archetype: {req.EnemyArchetype}, primal stakes: {req.PrimalStakes}, dramatic question: {req.DramaticQuestion}. {consolidatedContributions}"
        };

        return new OkObjectResult(result);
    }
}
