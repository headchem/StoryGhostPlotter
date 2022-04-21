using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StoryGhost.Models;
using StoryGhost.Models.Completions;

namespace StoryGhost.Interfaces;

public interface IEncodingService
{
    public Task<EncodingResponse> Encode(string text);
}