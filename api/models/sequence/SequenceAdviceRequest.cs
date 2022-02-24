using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace StoryGhost.Models;

public class SequenceAdviceRequest
{
    [JsonPropertyName("genres")]
    public List<string> Genres { get; set; }
    
    [JsonPropertyName("problemTemplate")]
    public string ProblemTemplate { get; set; }

    [JsonPropertyName("heroArchetype")]
    public string HeroArchetype { get; set; }

    // [JsonPropertyName("enemyArchetype")]
    // public string EnemyArchetype { get; set; }

    // [JsonPropertyName("primalStakes")]
    // public string PrimalStakes { get; set; }

    [JsonPropertyName("dramaticQuestion")]
    public string DramaticQuestion { get; set; }

    [JsonPropertyName("text")]
    public string Text { get; set; }
}