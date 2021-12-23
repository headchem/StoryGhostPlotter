using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.PrimalStakes;

public class FindMate : IPrimalStakes
{
    public string Id { get { return "findMate"; } }
    public string Name { get { return "Find Mate"; } }
    public string Description { get { return "Find Mate desc here"; } }
    public List<string> Keywords
    {
        get
        {
            return new List<string>{
                "lonliness", "connection"
            };
        }
    }

    public string GetLogLineContribution(IGenre genre, IProblemTemplate problemTemplate, IArchetype heroArchetype, IArchetype enemyArchetype, IDramaticQuestion dramaticQuestion)
    {
        return "Find Mate LogLine prompt contribution...";
    }

}