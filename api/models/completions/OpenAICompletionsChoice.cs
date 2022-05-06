using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace StoryGhost.Models.Completions;

public class OpenAICompletionsChoice
{
    [JsonPropertyName("text")]
    public string Text { get; set; }

    [JsonPropertyName("index")]
    public int Index { get; set; }

    ///<example>stop|length</example>
    [JsonPropertyName("finish_reason")]
    public string FinishReason { get; set; }
}