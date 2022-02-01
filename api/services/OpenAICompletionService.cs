using System;
using System.Net.Http;
using Microsoft.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System.Text;

using StoryGhost.Interfaces;
using StoryGhost.Models;
using StoryGhost.Util;
using StoryGhost.LogLine;

namespace StoryGhost.Services;

public class OpenAICompletionService : ICompletionService
{
    private readonly HttpClient _httpClient;

    public OpenAICompletionService(HttpClient httpClient)
    {
        _httpClient = httpClient;

        _httpClient.Timeout = TimeSpan.FromMinutes(5); // default is 100 sec

        _httpClient.BaseAddress = new Uri("https://api.openai.com/");
        //_httpClient.BaseAddress = new Uri("https://dasdf83jasdfhasd2jh3jhasdf.com/");


        var openAIKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY");

        // using Microsoft.Net.Http.Headers;
        // The GitHub API requires two headers.
        _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + openAIKey);
        //_httpClient.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/vnd.github.v3+json");
        //_httpClient.DefaultRequestHeaders.Add(HeaderNames.UserAgent, "HttpRequestsSample");
    }

    // public async Task<IEnumerable<GitHubBranch>?> GetAspNetCoreDocsBranchesAsync() =>
    //     await _httpClient.GetFromJsonAsync<IEnumerable<GitHubBranch>>(
    //         "repos/dotnet/AspNetCore.Docs/branches");

    public async Task<GenerateResponse> GetCompletion(Story story)
    {
        var prompt = Factory.GetPrompt(story);

        var models = getModels();

        // set sensible defaults based on how long we expect average completions for summary and full
        var maxCompletionLength = 1;
        var temperature = 1.0;

        if (story.CompletionType.ToLower().Contains("summary"))
        {
            maxCompletionLength = 192;
            temperature = 0.85;
        }
        else if (story.CompletionType.ToLower().Contains("full"))
        {
            maxCompletionLength = 512;
            temperature = 0.9;
        }

        var openAIRequest = new OpenAICompletionsRequest
        {
            Prompt = prompt,
            Model = models[story.CompletionType],
            MaxTokens = maxCompletionLength,
            Temperature = temperature,
            Stop = CreateFinetuningDataset.StopSequence // IMPORTANT: this must match exactly what we used during finetuning
        };

        var jsonString = System.Text.Json.JsonSerializer.Serialize(openAIRequest);
        var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

        //var apiResponse = await _httpClient.GetFromJsonAsync<OpenAICompletionsResponse>("repos/dotnet/AspNetCore.Docs/branches");

        using var response = await _httpClient.PostAsync("v1/completions", content);
        response.EnsureSuccessStatusCode(); // throws an exception if the response status code is anything but success

        var apiResponse = await response.Content.ReadAsStringAsync();
        var resultDeserialized = System.Text.Json.JsonSerializer.Deserialize<OpenAICompletionsResponse>(apiResponse);

        var result = new GenerateResponse();

        var completionObj = resultDeserialized.Choices.FirstOrDefault();
        var completion = completionObj == null ? "" : completionObj.Text.Trim();

        result.Prompt = prompt;
        result.Completion = completion;

        return result;
    }

    private static Dictionary<string, string> getModels()
    {
        var models = new Dictionary<string, string>(); // key=completion type, value=finetuned model name

        //OLD request delete! models.Add("orphanSummary", "davinci:ft-personal-2022-01-07-03-57-47"); // file: ???
        // OLD models.Add("orphanSummary", "davinci:ft-personal-2022-01-14-07-09-45"); // file: file-Ume90SHsl7fZrKi3CUZYpWvv
        // OLD models.Add("orphanFull", "davinci:ft-personal-2022-01-14-07-33-38"); // file: file-WInOrbv1OUtTjPxVJhLXM52E
        //models.Add("orphanSummary", "davinci:ft-personal-2022-01-14-20-10-28"); // file: file-y0DyC2OllYkIac7IVlWWPreg
        models.Add("orphanSummary", "davinci:ft-personal-2022-01-14-20-37-11"); // file: file-dgqvXcXRPGozYDRw51QOUgjG
        models.Add("orphanFull", "davinci:ft-personal-2022-01-14-19-46-56"); // file: file-qdh65y1NlmZcfTtRuY1aFw5y
        models.Add("wandererSummary", "davinci:ft-personal-2022-01-17-05-54-33"); // file: file-NsboEGXUSkMnnOU3i1Gl9Ena
        models.Add("wandererFull", "davinci:ft-personal-2022-01-17-06-30-49"); // file: file-tyog5wRUgFdWkgWZoPueNPI2
        models.Add("warriorSummary", "davinci:ft-personal-2022-01-18-04-17-36"); // file: file-0O2o8DDY7Lh55WAxTu1le26g
        models.Add("warriorFull", "davinci:ft-personal-2022-01-18-04-24-32"); // file: file-ACTIYBCFNHuiflu1SXNKIE2F
        models.Add("martyrSummary", "davinci:ft-personal-2022-01-18-04-45-55"); // file: file-et3zf0arSUtAhI55yPcH3RTI
        models.Add("martyrFull", "davinci:ft-personal-2022-01-18-04-58-53");// $4.74 to finetune with 30 examples on davinci, file: file-iv17D0PBMkBpvpteUVHhNuKy

        return models;
    }
}