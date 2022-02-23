using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using StoryGhost.Models;

namespace StoryGhost.Interfaces;

public interface ICompletionService
{
    public Task<GenerateResponse> GetLogLineDescriptionCompletion(Plot story);
    public Task<GenerateResponse> GetSequenceCompletion(string sequenceName, Plot story);

    public Task<GenerateResponse> GetCharacterCompletion(string archetype, Plot story);
}