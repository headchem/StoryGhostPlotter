using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.Genres;

public class Sports : IGenre
{
    public string Id { get { return "sports"; } }
    public string Name { get { return "Sports"; } }
    public string Description { get { return "The Sports genre focuses on a game that dominates the Hero's life. The game is a backdrop for the Hero's struggles to overcome adversity."; } }
    public List<string> Keywords
    {
        get
        {
            return new List<string>{
                "game", "losing", "winning", "overcome", "skill"
            };
        }
    }

    public string GetLogLineContribution(int seed, IProblemTemplate problemTemplate, IArchetype heroArchetype, IArchetype enemyArchetype, IPrimalStakes primalStakes, IDramaticQuestion dramaticQuestion)
    {
        return $"The genre is {Name}, which involves {string.Join(", ", Keywords)}.";
    }

}