using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.PrimalStakes;

public class Survive : IPrimalStakes
{
    public string Id { get { return "survive"; } }
    public string Name { get { return "Survive"; } }
    public string Description { get { return "An Enemy threatens the safety of the Hero's identity or physical existence. The Hero's will to persevere is tested, but they ultimately find peace."; } }
    public List<string> Keywords
    {
        get
        {
            return new List<string>{
                "safety", "danger", "resist"
            };
        }
    }

    public string GetLogLineContribution(int seed, IGenre genre, IProblemTemplate problemTemplate, IArchetype heroArchetype, IArchetype enemyArchetype, IDramaticQuestion dramaticQuestion)
    {
        return "Survive LogLine prompt contribution...";
    }

}