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
using StoryGhost.Models.Completions;
using StoryGhost.Util;
using StoryGhost.LogLine;
using StoryGhost.Util;

namespace StoryGhost.Services;

public class DummyCompletionService : ICompletionService
{

    private readonly HttpClient _httpClient;

    public DummyCompletionService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Dictionary<string, CompletionResponse>> GetLogLineDescriptionCompletion(Plot story, int keywordsLogitBias)
    {
        var prompt = "TODO log line desc prompt goes here...";

        var result = new CompletionResponse();

        result.Prompt = prompt;
        result.Completion = "AI Log Line Description completion goes here...";

        return new Dictionary<string, CompletionResponse> { ["finetuned"] = result };
    }

    public async Task<CompletionResponse> GetSequenceCompletion(string part, Plot story)
    {
        //var prompt = Factory.GetSequencePrompt(sequenceName, story);

        var promptSequenceText = CreateFinetuningDataset.GetPromptSequenceText(part, story);
        var prompt = Factory.GetSequencePartPrompt(part, story, promptSequenceText);

        var result = new CompletionResponse();

        result.Prompt = prompt;
        result.Completion = "AI SEQUENCE completion goes here...";

        return result;
    }

    public async Task<CompletionResponse> GetCharacterCompletion(Character character)
    {
        var prompt = "TODO character archetype prompt goes here...";

        var result = new CompletionResponse();

        result.Prompt = prompt;
        result.Completion = "AI CHARACTER completion goes here...";

        return result;
    }

}