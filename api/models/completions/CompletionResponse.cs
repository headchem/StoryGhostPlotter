using System;
using System.Collections.Generic;

namespace StoryGhost.Models.Completions;

public class CompletionResponse
{
    public string Prompt { get; set; }
    public int PromptTokenCount { get; set; }
    public string Completion { get; set; }
    public int CompletionTokenCount { get; set; }
}