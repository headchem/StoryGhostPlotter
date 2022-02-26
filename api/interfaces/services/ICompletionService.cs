using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StoryGhost.Models;
using StoryGhost.Models.Completions;

namespace StoryGhost.Interfaces;

public interface ICompletionService
{
    public Task<LogLineResponse> GetLogLineDescriptionCompletion(Plot story);
    public Task<SequenceResponse> GetSequenceCompletion(string sequenceName, Plot story);

    public Task<SequenceResponse> GetCharacterCompletion(string archetype, Plot story);
}