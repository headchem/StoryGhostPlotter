using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.IO;
using System.Linq;
using System.Text;
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

public static class Generate
{
    [FunctionName("Generate")]
    public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] Story req, ILogger log)
    {
        var prompt = Factory.GetPrompt(req);

        // TEMP
        return new OkObjectResult(new GenerateResponse
        {
            Prompt = prompt,
            Completion = "completion for " + req.CompletionType
        });

        // var models = getModels();

        // var openAIRequest = new OpenAICompletionsRequest
        // {
        //     Prompt = prompt,
        //     Model = models[req.CompletionType],
        //     MaxTokens = 64,
        //     Temperature = 0.9,
        //     Stop = "###"
        // };

        // var jsonString = System.Text.Json.JsonSerializer.Serialize(openAIRequest);
        // var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

        // var openAIKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY");

        // using var httpClient = new HttpClient();
        // httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + openAIKey);

        // using var response = await httpClient.PostAsync("https://api.openai.com/v1/completions", content);
        // var apiResponse = await response.Content.ReadAsStringAsync();
        // var resultDeserialized = System.Text.Json.JsonSerializer.Deserialize<OpenAICompletionsResponse>(apiResponse);

        // var completionObj = resultDeserialized.Choices.FirstOrDefault();
        // var completion = completionObj == null ? "" : completionObj.Text.Trim();

        // var result = new GenerateResponse
        // {
        //     Prompt = prompt,
        //     Completion = completion
        // };

        // return new OkObjectResult(result);
    }

    // private static Dictionary<string, string> getModels() {
    //     var models = new Dictionary<string, string>(); // key=completion type, value=finetuned model name

    //     models.Add("orphanSummary", "davinci:ft-personal-2022-01-07-03-57-47");
    //     models.Add("orphanFull", "davinci:ft-personal-2022-01-07-03-57-47");
    //     models.Add("wandererSummary", "davinci:ft-personal-2022-01-07-03-57-47");
    //     models.Add("wandererFull", "davinci:ft-personal-2022-01-07-03-57-47");
    //     models.Add("warriorSummary", "davinci:ft-personal-2022-01-07-03-57-47");
    //     models.Add("warriorFull", "davinci:ft-personal-2022-01-07-03-57-47");
    //     models.Add("martyrSummary", "davinci:ft-personal-2022-01-07-03-57-47");
    //     models.Add("martyrFull", "davinci:ft-personal-2022-01-07-03-57-47");

    //     return models;
    // }

}
