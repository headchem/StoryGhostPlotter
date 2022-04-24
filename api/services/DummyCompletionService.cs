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

    public async Task<CompletionResponse> GetSequenceCompletion(string targetSequence, int maxTokens, double temperature, Plot story)
    {
        //var prompt = Factory.GetSequencePrompt(sequenceName, story);

        var promptSequenceText = CreateFinetuningDataset.GetSequenceTextUpTo(targetSequence, story);
        var prompt = Factory.GetSequencePartPrompt(targetSequence, story, promptSequenceText);

        var result = new CompletionResponse();

        result.Prompt = prompt;
        result.Completion = "AI SEQUENCE completion for " + targetSequence + " goes here...";

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

    public async Task<List<string>> GetTitles(List<string> genres, string logLineDescription) {
        
        return new List<string>{
            "Title 1",
            "Title 2",
            "Title 3",
            "Title 4",
            "Title 5"
        };
    }

    public async Task<List<UserSequence>> GenerateAllSequences(Plot story) {
        return new List<UserSequence>();
    }

}