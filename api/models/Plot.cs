using System;
using System.Collections.Generic;

namespace StoryGhost.Models;

public class Plot
{
    public string CompletionType { get; set; } // orphanSummary, orphanFull, wandererSummary, wandererFull, warriorSummary, warriorFull, martyrSummary, martyrFull
    public string Genre { get; set; }
    public string ProblemTemplate { get; set; }
    public List<string> Keywords { get; set; }
    public string HeroArchetype { get; set; }
    public string EnemyArchetype { get; set; }
    public string PrimalStakes { get; set; }
    public string DramaticQuestion { get; set; }
    public int Seed { get; set; }

    public string OrphanSummary { get; set; }
    public string OrphanFull { get; set; }
    public string WandererSummary { get; set; }
    public string WandererFull { get; set; }
    public string WarriorSummary { get; set; }
    public string WarriorFull { get; set; }
    public string MartyrSummary { get; set; }
    public string MartyrFull { get; set; }
}