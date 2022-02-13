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


    // seems redundant to persist below to disk, maybe derive via C# logic instead of pulling from Cosmos?

    [JsonPropertyName("isLocked")]
    public bool IsLocked { get; set; }

    [JsonPropertyName("isReadOnly")]
    public bool isReadOnly { get; set; }

    [JsonPropertyName("allowed")]
    public List<string> Allowed { get; set; }
}