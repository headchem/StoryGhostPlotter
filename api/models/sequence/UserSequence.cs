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

    // skipping [isLocked, isReadOnly, allowed] because they're not needed on the server side
}