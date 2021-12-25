using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.PrimalStakes;

public class FindMate : IPrimalStakes
{
    public string Id { get { return "findMate"; } }
    public string Name { get { return "find a mate"; } }
    public string Description { get { return "The Hero lacks a deep connection in life, but they are irresistably drawn to another entity that is seemingly incompatible. As the two learn more about each other, they develop a strong bond."; } }
    public List<string> Keywords
    {
        get
        {
            return new List<string>{
                "lonliness", "rescue", "connection", "passion"
            };
        }
    }

    public string GetLogLineContribution(int seed, IGenre genre, IProblemTemplate problemTemplate, IArchetype heroArchetype, IArchetype enemyArchetype, IDramaticQuestion dramaticQuestion)
    {
        return $"The primal stakes are to {Name}, which involves {string.Join(", ", Keywords)}.";
    }

}