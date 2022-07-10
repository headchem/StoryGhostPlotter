using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using StoryGhost.Models.Completions;

namespace StoryGhost.Models;

public class UserSequence
{
    [JsonPropertyName("sequenceName")]
    public string SequenceName { get; set; }

    [JsonPropertyName("blurb")]
    public string Blurb { get; set; }

    ///<summary>This is the expanded summary</summary>
    [JsonPropertyName("text")]
    public string Text { get; set; }


    [JsonPropertyName("blurbCompletions")]
    public List<CompletionResponse> BlurbCompletions { get; set; }

    ///<summary>These are the completions for the expanded summary</summary>
    [JsonPropertyName("completions")]
    public List<CompletionResponse> Completions { get; set; }


    [JsonPropertyName("scenes")]
    public List<UserScene> Scenes { get; set; }
}