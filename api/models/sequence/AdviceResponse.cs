using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace StoryGhost.Models;

public class AdviceResponse
{
    [JsonPropertyName("advice")]
    public string Advice { get; set; }
}