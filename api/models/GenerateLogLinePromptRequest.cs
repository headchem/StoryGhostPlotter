using System;
using System.Collections.Generic;

namespace StoryGhost.Models;

public class GenerateLogLineProptRequest
{
    public string Genre { get; set; }
    public string ProblemTemplate { get; set; }
    public List<string> Keywords { get; set; }
    public string HeroArchetype { get; set; }
    public string EnemyArchetype { get; set; }
    public string PrimalStakes { get; set; }
    public string DramaticQuestion { get; set; }
    public int Seed { get; set; }
}