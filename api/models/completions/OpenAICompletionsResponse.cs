using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace StoryGhost.Models.Completions;

public class OpenAICompletionsResponse
{
    // I think this is an OpenAI completion id, for example: cmpl-58JqNZFseM1Z2IA4KPdFGIqHDADGf
    [JsonPropertyName("id")]
    public string Id { get; set; }

    // example: "text_completion"
    [JsonPropertyName("object")]
    public string Object { get; set; }

    [JsonPropertyName("created")]
    public int Created { get; set; }

    [JsonPropertyName("model")]
    public string Model { get; set; }

    [JsonPropertyName("choices")]
    public List<OpenAICompletionsChoice> Choices { get; set; }

    [JsonPropertyName("usage")]
    public OpenAICompletionsUsage Usage { get; set; }
}