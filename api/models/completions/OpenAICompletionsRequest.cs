using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace StoryGhost.Models.Completions;

public class OpenAICompletionsRequest
{
    [JsonPropertyName("prompt")]
    public string Prompt { get; set; }

    [JsonPropertyName("model")]
    public string Model { get; set; }

    [JsonPropertyName("max_tokens")]
    public int MaxTokens { get; set; }
    
    [JsonPropertyName("n")]
    public int NumCompletions { get; set; }

    [JsonPropertyName("temperature")]
    public double Temperature { get; set; }

    [JsonPropertyName("stop")]
    public string Stop { get; set; }

    [JsonPropertyName("logit_bias")]
    public Dictionary<string, int> LogitBias { get; set; }

    /// 0.1 means only select tokens from the top 10% of all possibilities. Either use this property, or Temperature, but not both. This defaults to 1.0 if not set.
    [JsonPropertyName("top_p")]
    public double TopP { get; set; }

    /// Number between -2.0 and 2.0. Positive values penalize new tokens based on their existing frequency in the text so far, decreasing the model's likelihood to repeat the same line verbatim. Reasonable values for the penalty coefficients are around 0.1 to 1 if the aim is to just reduce repetitive samples somewhat. If the aim is to strongly suppress repetition, then one can increase the coefficients up to 2, but this can noticeably degrade the quality of samples. Negative values can be used to increase the likelihood of repetition. IMPORTANT: higher values also penalize repetition of common punctuation like "." so you don't want to increase it too much.
    [JsonPropertyName("frequency_penalty")]
    public double FrequencyPenalty { get; set; }

    /// Number between -2.0 and 2.0. Positive values penalize new tokens based on whether they appear in the text so far, increasing the model's likelihood to talk about new topics. Reasonable values for the penalty coefficients are around 0.1 to 1 if the aim is to just reduce repetitive samples somewhat. If the aim is to strongly suppress repetition, then one can increase the coefficients up to 2, but this can noticeably degrade the quality of samples. Negative values can be used to increase the likelihood of repetition. IMPORTANT: higher values also penalize repetition of common punctuation like "." so you don't want to increase it too much.
    [JsonPropertyName("presence_penalty")]
    public double PresencePenalty { get; set; }

    /// Include the log probabilities on the logprobs most likely tokens, as well the chosen tokens. For example, if logprobs is 10, the API will return a list of the 10 most likely tokens.
    [JsonPropertyName("logprobs")]
    public int? Logprobs { get; set; }

    // From OpenAI documentation: "To help with monitoring for possible misuse, developers serving multiple end-users should pass an additional user parameter to OpenAI with each API call, in which user is a unique ID representing a particular end-user."
    [JsonPropertyName("user")]
    public string UserId { get; set; }

}