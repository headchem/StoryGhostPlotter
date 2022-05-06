using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace StoryGhost.Models.Completions;

public class TitlesResponse
{
    public List<string> Titles { get; set; }

    public CompletionResponse CompletionResponse { get; set; }
}