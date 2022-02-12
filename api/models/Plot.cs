using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace StoryGhost.Models;

public class Plot
{
    public string Id { get; set; }
    
    //[JsonPropertyName("UserId")]
    public string UserId { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }
    //public string CompletionType { get; set; } // orphanSummary, orphanFull, wandererSummary, wandererFull, warriorSummary, warriorFull, martyrSummary, martyrFull
    public string Genre { get; set; }
    public string ProblemTemplate { get; set; }
    public List<string> Keywords { get; set; }
    public string HeroArchetype { get; set; }
    public string EnemyArchetype { get; set; }
    public string PrimalStakes { get; set; }
    public string DramaticQuestion { get; set; }
    public long Seed { get; set; }

    // public string OrphanSummary { get; set; }
    // public string OrphanFull { get; set; }
    // public string WandererSummary { get; set; }
    // public string WandererFull { get; set; }
    // public string WarriorSummary { get; set; }
    // public string WarriorFull { get; set; }
    // public string MartyrSummary { get; set; }
    // public string MartyrFull { get; set; }

    public List<UserSequence> Sequences { get; set; }
}