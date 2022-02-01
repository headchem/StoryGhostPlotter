using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using StoryGhost.Models;

namespace StoryGhost.Interfaces;

public interface ICompletionService
{
    public Task<GenerateResponse> GetCompletion(Story story);
}