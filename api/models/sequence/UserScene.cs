using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using StoryGhost.Models.Completions;

namespace StoryGhost.Models;

public class UserScene
{
    public Guid Id { get; set; }

    [JsonPropertyName("summary")]
    public string Summary { get; set; }

    [JsonPropertyName("full")]
    public string Full { get; set; }

    [JsonPropertyName("summaryCompletions")]
    public List<CompletionResponse> SummaryCompletions { get; set; }

    [JsonPropertyName("fullCompletions")]
    public List<CompletionResponse> FullCompletions { get; set; }

    [JsonPropertyName("startEmotion")]
    public SceneEmotion StartEmotion {get;set;}

    [JsonPropertyName("endEmotion")]
    public SceneEmotion EndEmotion {get;set;}
}