using System;
using System.Collections.Generic;

namespace StoryGhost.Models.Completions;

public class LogLineResponse
{
    public string Prompt { get; set; }
    /// The last item is the finished completion, with the previous completions being the building blocks that were used by other prompts.
    public string Completion { get; set; }
}