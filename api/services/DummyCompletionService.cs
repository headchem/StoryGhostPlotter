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

namespace StoryGhost.Services;

public class DummyCompletionService : ICompletionService
{

    private readonly HttpClient _httpClient;

    public DummyCompletionService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Dictionary<string, LogLineResponse>> GetLogLineDescriptionCompletion(Plot story, int keywordsLogitBias)
    {
        var prompt = "TODO log line desc prompt goes here...";

        var result = new LogLineResponse();

        result.Prompt = prompt;
        result.Completion = "AI Log Line Description completion goes here...";

        return new Dictionary<string, LogLineResponse> { ["finetuned"] = result };
    }

    public async Task<SequenceResponse> GetSequenceCompletion(string sequenceName, Plot story)
    {
        var prompt = Factory.GetSequencePrompt(sequenceName, story);

        var result = new SequenceResponse();

        result.Prompt = prompt;
        result.Completion = "AI SEQUENCE completion goes here...";

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