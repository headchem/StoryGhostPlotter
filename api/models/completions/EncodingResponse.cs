using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace StoryGhost.Models.Completions;

public class EncodingResponse
{
    [JsonPropertyName("count")]
    public int Count { get; set; }

    [JsonPropertyName("tokens")]
    public List<int> Tokens { get; set; }
}