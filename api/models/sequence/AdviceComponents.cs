using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace StoryGhost.Models;

public class AdviceComponents
{
    //[JsonPropertyName("sequenceName")]
    public string Common { get; set; }
    public string Genre { get; set; }
    public string ProblemTemplate { get; set; }
    public string HeroArchetype { get; set; }
    public string EnemyArchetype { get; set; }
    public string PrimalStakes { get; set; }
    public string DramaticQuestion { get; set; }


}