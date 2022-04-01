using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StoryGhost.Models;
using StoryGhost.Models.Completions;

namespace StoryGhost.Interfaces;

public interface ICompletionService
{
    public Task<Dictionary<string, CompletionResponse>> GetLogLineDescriptionCompletion(Plot story, int keywordLogitBias);
    public Task<CompletionResponse> GetSequenceCompletion(string sequenceName, Plot story);

    public Task<CompletionResponse> GetCharacterCompletion(Character character);
}