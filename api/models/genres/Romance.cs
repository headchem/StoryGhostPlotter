using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.Genres;

public class Romance : IGenre
{
    public string Id { get { return "romance"; } }
    public string Name { get { return "Romance"; } }
    public string Description { get { return "Romance focuses on the relationship and courtship between two people."; } }
    public List<string> Keywords
    {
        get
        {
            return new List<string>{
                "love", "longing"
            };
        }
    }

    public AdviceSequence AdviceSequence
    {
        get
        {
            return new AdviceSequence
            {
            };
        }
    }

    public string GetLogLineContribution(long seed, IProblemTemplate problemTemplate, IArchetype heroArchetype, IArchetype enemyArchetype, IPrimalStakes primalStakes, IDramaticQuestion dramaticQuestion)
    {
        return $"This is an award winning romance story focusing on the romantic tension and courtship between two characters.";
    }

}