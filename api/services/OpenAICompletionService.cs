using System;
using System.Net.Http;
using Microsoft.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

using StoryGhost.Interfaces;
using StoryGhost.Models;
using StoryGhost.Models.Completions;
using StoryGhost.Util;
using StoryGhost.LogLine;

namespace StoryGhost.Services;

public class OpenAICompletionService : ICompletionService
{
    private readonly HttpClient _httpClient;

    public OpenAICompletionService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<LogLineResponse> GetLogLineDescriptionCompletion(Plot plot)
    {
        var prompt = string.Join(", ", plot.Genres.OrderBy(a => Guid.NewGuid()).ToList()) + CreateFinetuningDataset.PromptSuffix;

        /*
DELETED: "babbage:ft-personal-2022-02-25-07-36-34" = openai api fine_tunes.create -t "logline.jsonl" -m babbage --n_epochs 2 --learning_rate_multiplier 0.02
"babbage:ft-personal-2022-02-26-07-23-02" = openai api fine_tunes.create -t "logline.jsonl" -m babbage --n_epochs 2 --batch_size 64 --learning_rate_multiplier 0.1
"babbage:ft-personal-2022-02-27-22-34-14" = openai api fine_tunes.create -t "logline.jsonl" -m babbage --n_epochs 1 --batch_size 64 --learning_rate_multiplier 0.2
DELETED: "curie:ft-personal-2022-02-27-23-06-32" = openai api fine_tunes.create -t "logline.jsonl" -m curie --n_epochs 1 --batch_size 64 --learning_rate_multiplier 0.02
"curie:ft-personal-2022-02-27-23-31-57" = openai api fine_tunes.create -t "logline.jsonl" -m curie --n_epochs 2 --batch_size 64 --learning_rate_multiplier 0.08
        */

        var openAIRequest = new OpenAICompletionsRequest
        {
            Prompt = prompt,
            Model = "curie:ft-personal-2022-02-27-23-31-57", //,
            MaxTokens = 200, // longest log line prompt was 167 tokens,
            Temperature = 0.85,
            Stop = CreateFinetuningDataset.CompletionStopSequence // IMPORTANT: this must match exactly what we used during finetuning
        };

        var jsonString = JsonSerializer.Serialize(openAIRequest);
        var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync("completions", content);
        response.EnsureSuccessStatusCode(); // throws an exception if the response status code is anything but success

        var apiResponse = await response.Content.ReadAsStringAsync();
        var resultDeserialized = JsonSerializer.Deserialize<OpenAICompletionsResponse>(apiResponse);

        var completionObj = resultDeserialized.Choices.FirstOrDefault();
        var completion = completionObj == null ? "" : completionObj.Text.Trim();

        //var completionTitle = "";
        //var completionDescription = "";

        // var completionParts = completion.Split(" --- ");
        // if (completionParts.Length > 1)
        // { // it should always have 2 parts, but we check just in case
        //     completionDescription = completionParts[0];
        //     completionTitle = completionParts[1];
        // }
        // else
        // {
        //     completionDescription = completion;
        // }

        var result = new LogLineResponse
        {
            Prompt = prompt,
            //Title = completionTitle,
            Completion = completion
        };

        return result;
    }

    public async Task<SequenceResponse> GetSequenceCompletion(string sequenceName, Plot story)
    {
        return new SequenceResponse
        {
            Prompt = "prompt goes here",
            Completion = "AI Sequence completion goes here..."
        };

        var prompt = Factory.GetSequencePrompt(sequenceName, story);

        //var models = getModels();

        // set sensible defaults based on how long we expect average completions for summary and full
        var maxCompletionLength = 1;
        var temperature = 1.0;

        // if (story.CompletionType.ToLower().Contains("summary"))
        // {
        //     maxCompletionLength = 160; // average 80 tokens on training data
        //     temperature = 0.85;
        // }
        // else if (story.CompletionType.ToLower().Contains("full"))
        // {
        //     maxCompletionLength = 400; // average 295 tokens on training data
        //     temperature = 0.9;
        // }

        var openAIRequest = new OpenAICompletionsRequest
        {
            Prompt = prompt,
            //Model = models[story.CompletionType], // TODO, update completion type with new sequence/beat structure
            MaxTokens = maxCompletionLength,
            Temperature = temperature,
            Stop = CreateFinetuningDataset.CompletionStopSequence // IMPORTANT: this must match exactly what we used during finetuning
        };

        var jsonString = System.Text.Json.JsonSerializer.Serialize(openAIRequest);
        var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

        //var apiResponse = await _httpClient.GetFromJsonAsync<OpenAICompletionsResponse>("repos/dotnet/AspNetCore.Docs/branches");

        //using var response = await _httpClient.PostAsync("v1/completions", content);
        var response = await _httpClient.PostAsync("completions", content);
        response.EnsureSuccessStatusCode(); // throws an exception if the response status code is anything but success

        var apiResponse = await response.Content.ReadAsStringAsync();
        var resultDeserialized = System.Text.Json.JsonSerializer.Deserialize<OpenAICompletionsResponse>(apiResponse);

        var result = new SequenceResponse();

        var completionObj = resultDeserialized.Choices.FirstOrDefault();
        var completion = completionObj == null ? "" : completionObj.Text.Trim();

        result.Prompt = prompt;
        result.Completion = completion;

        return result;
    }

    public async Task<SequenceResponse> GetCharacterCompletion(string archetype, Plot story)
    {
        var prompt = "TODO character archetype prompt goes here...";

        var result = new SequenceResponse();

        result.Prompt = prompt;
        result.Completion = "AI CHARACTER completion goes here...";

        return result;
    }
}