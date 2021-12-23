using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.PrimalStakes;

public class ExactRevenge : IPrimalStakes
{
    public string Id { get { return "exactRevenge"; } }
    public string Name { get { return "Exact Revenge"; } }
    public string Description { get { return "Exact Revenge desc here"; } }
    public List<string> Keywords
    {
        get
        {
            return new List<string>{
                "seething", "catharsis"
            };
        }
    }

    public string GetLogLineContribution(IGenre genre, IProblemTemplate problemTemplate, IArchetype heroArchetype, IArchetype enemyArchetype, IDramaticQuestion dramaticQuestion)
    {
        return "Exact Revenge LogLine prompt contribution...";
    }

}