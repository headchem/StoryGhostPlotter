using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StoryGhost.Models;
using StoryGhost.Models.Completions;

namespace StoryGhost.Interfaces;

public interface ICompletionService
{
    public Task<Dictionary<string, LogLineResponse>> GetLogLineDescriptionCompletion(Plot story, int keywordLogitBias);
    public Task<SequenceResponse> GetSequenceCompletion(string sequenceName, Plot story);

    //public Task<SequenceResponse> GetCharacterCompletion(string archetype, Plot story);
}