using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace StoryGhost.Models;

public class UserSequence
{
    [JsonPropertyName("sequenceName")]
    public string SequenceName { get; set; }

    [JsonPropertyName("text")]
    public string Text { get; set; }

    [JsonPropertyName("aiText")]
    /// <summary>Includes both the AI-generated Context as well as Sequence events</summary>
    public string AIText { get; set; }

    [JsonPropertyName("context")]
    public string Context { get; set; }

}