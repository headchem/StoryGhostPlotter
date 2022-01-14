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

        // // set sensible defaults based on how long we expect average completions for summary and full
        // var maxCompletionLength = 1;
        // var temperature = 1.0;

        // if (req.CompletionType.ToLower().Contains("summary")) {
        //     maxCompletionLength = 256;
        //     temperature = 0.9;
        // } else if (req.CompletionType.ToLower().Contains("full")) {
        //     maxCompletionLength = 512;
        //     temperature = 0.8;
        // }

        // var openAIRequest = new OpenAICompletionsRequest
        // {
        //     Prompt = prompt,
        //     Model = models[req.CompletionType],
        //     MaxTokens = maxCompletionLength,
        //     Temperature = temperature,
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

    //     //OLD request delete! models.Add("orphanSummary", "davinci:ft-personal-2022-01-07-03-57-47");
    //     models.Add("orphanSummary", "davinci:ft-personal-2022-01-14-07-09-45"); // file: file-Ume90SHsl7fZrKi3CUZYpWvv
    //     models.Add("orphanFull", "davinci:ft-personal-2022-01-14-07-33-38"); // file: file-WInOrbv1OUtTjPxVJhLXM52E
    //     models.Add("wandererSummary", "davinci:ft-personal-2022-01-07-03-57-47");
    //     models.Add("wandererFull", "davinci:ft-personal-2022-01-07-03-57-47");
    //     models.Add("warriorSummary", "davinci:ft-personal-2022-01-07-03-57-47");
    //     models.Add("warriorFull", "davinci:ft-personal-2022-01-07-03-57-47");
    //     models.Add("martyrSummary", "davinci:ft-personal-2022-01-07-03-57-47");
    //     models.Add("martyrFull", "davinci:ft-personal-2022-01-07-03-57-47");

    //     return models;
    // }

}
