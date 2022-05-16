using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using StoryGhost.Models.Completions;

namespace StoryGhost.Models;

public class UserSequence
{
    [JsonPropertyName("sequenceName")]
    public string SequenceName { get; set; }

    [JsonPropertyName("text")]
    public string Text { get; set; }

    [JsonPropertyName("completions")]
    public List<CompletionResponse> Completions { get; set; }
}