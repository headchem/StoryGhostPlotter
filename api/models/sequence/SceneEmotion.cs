using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using StoryGhost.Models.Completions;

namespace StoryGhost.Models;

public class SceneEmotion
{

    ///<summary>ecstacy | love | admiration | submission | fear | awe | amazement | disapproval | grief | remorse | loathing | contempt | rage | aggressiveness | vigilance | optimism</summary>
    [JsonPropertyName("emotion")]
    public string Emotion { get; set; }

    ///<summary>mild | intense</summary>
    [JsonPropertyName("intensity")]
    public string Intensity { get; set; }

}