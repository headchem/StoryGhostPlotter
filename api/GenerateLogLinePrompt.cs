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

namespace StoryGhost.Generate;

public static class GenerateLogLinePrompt
{
    [FunctionName("GenerateLogLinePrompt")]
    public static IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] GenerateLogLineProptRequest req, ILogger log)
    {
        var result = new GenerateLogLinePromptResponse{
            Prompt = $"this is the GPT-3 prompt with the following inputs: genre: {req.Genre}, problem template: {req.ProblemTemplate}, keywords: {string.Join("; ", req.Keywords)}, hero archetype: {req.HeroArchetype}, enemy archetype: {req.EnemyArchetype}, primal stakes: {req.PrimalStakes}, dramatic question: {req.DramaticQuestion}"
        };

        return new OkObjectResult(result);
    }
}
