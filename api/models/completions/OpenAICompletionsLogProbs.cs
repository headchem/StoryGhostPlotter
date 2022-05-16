using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace StoryGhost.Models.Completions;

public class OpenAICompletionsLogProbs
{
    [JsonPropertyName("tokens")]
    public List<string> Tokens { get; set; }

    [JsonPropertyName("token_logprobs")]
    public List<double> TokenLogProbs { get; set; }

    [JsonPropertyName("top_logprobs")]
    public List<Dictionary<string, double>> TopLogProbs { get; set; }

}