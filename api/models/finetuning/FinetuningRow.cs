using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace StoryGhost.Finetuning.Models;

public class FinetuningRow
{
    //public string SequenceName { get; set; }
    [JsonPropertyName("prompt")]
    public string Prompt { get; set; }

    [JsonPropertyName("completion")]
    public string Completion { get; set; }
}