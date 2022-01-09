using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.PrimalStakes;

public class ProtectFamily : IPrimalStakes
{
    public string Id { get { return "protectFamily"; } }
    public string Name { get { return "protect one's family"; } }
    public string Description { get { return "The Hero's family is threatened by a dangerous outsider. Despite conflicts within the family, their bonds cannot be broken, and the Hero will stop at nothing to protect them."; } }
    public List<string> Keywords
    {
        get
        {
            return new List<string>{
                "safety", "threat", "bonds"
            };
        }
    }

    public string GetLogLineContribution(int seed, IGenre genre, IProblemTemplate problemTemplate, IArchetype heroArchetype, IArchetype enemyArchetype, IDramaticQuestion dramaticQuestion)
    {
        return $"This story eventually ends with the main character protecting their family.";
    }

}