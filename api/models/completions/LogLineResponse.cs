using System;
using System.Collections.Generic;

namespace StoryGhost.Models.Completions;

public class CompletionResponse
{
    public string Prompt { get; set; }
    public string Completion { get; set; }
}