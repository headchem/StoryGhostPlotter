using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using StoryGhost.Models.Completions;

namespace StoryGhost.Models;

public class Plot
{

    public string DataType { get { return "Plot"; } } // used to track type in Cosmos DB
    public string DataVersion { get { return "1.0"; } } // used to track schema version in Cosmos DB

    public string Id { get; set; }

    //[JsonPropertyName("UserId")]
    public string UserId { get; set; }

    public string LogLineDescription { get; set; }

    [JsonPropertyName("AILogLineDescriptions")]
    public List<Dictionary<string, CompletionResponse>> AILogLineDescriptions { get; set; }
    public string AILogLineTitle { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }
    //public string CompletionType { get; set; } // orphanSummary, orphanFull, wandererSummary, wandererFull, warriorSummary, warriorFull, martyrSummary, martyrFull
    public List<string> Genres { get; set; }
    public string ProblemTemplate { get; set; }
    public List<string> Keywords { get; set; }
    // public string HeroArchetype { get; set; }
    // public string EnemyArchetype { get; set; }

    public List<Character> Characters { get; set; }

    //public string PrimalStakes { get; set; }
    public string DramaticQuestion { get; set; }
    public long Seed { get; set; }

    /// <summary>UTC date the plot was first created.</summary>
    public DateTime Created { get; set; }

    /// <summary>UTC date any property of the plot (including sequences) was last modified.</summary>
    public DateTime Modified { get; set; }

    public bool IsDeleted { get; set; }
    public bool IsPublic { get; set; }

    [JsonPropertyName("sequences")]
    public List<UserSequence> Sequences { get; set; }
}