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

public class DummyCompletionService : ICompletionService
{

    public DummyCompletionService(HttpClient httpClient)
    {
    }

    public async Task<GenerateResponse> GetCompletion(Story story)
    {
        var prompt = Factory.GetPrompt(story);

        var result = new GenerateResponse();

        result.Prompt = prompt;
        result.Completion = "dummy completion goes here";

        return result;
    }

}