using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.PrimalStakes;

public class ExactRevenge : IPrimalStakes
{
    public string Id { get { return "exactRevenge"; } }
    public string Name { get { return "exact revenge"; } }
    public string Description { get { return "After the Hero is betrayed, they seek justice against the entities that harmed them."; } }
    public List<string> Keywords
    {
        get
        {
            return new List<string>{
                "betrayal", "seething", "catharsis", "justice"
            };
        }
    }

    public string GetLogLineContribution(int seed, IGenre genre, IProblemTemplate problemTemplate, IArchetype heroArchetype, IArchetype enemyArchetype, IDramaticQuestion dramaticQuestion)
    {
        return $"The primal stakes are to {Name}, which involves {string.Join(", ", Keywords)}.";
    }

}