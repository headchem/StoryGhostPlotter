using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.Genres;

public class Romance : IGenre
{
    public string Id { get { return "romance"; } }
    public string Name { get { return "Romance"; } }
    public string Description { get { return "Romance desc here"; } }
    public List<string> Keywords
    {
        get
        {
            return new List<string>{
                "love", "longing"
            };
        }
    }

    public string GetLogLineContribution(IProblemTemplate problemTemplate, IArchetype heroArchetype, IArchetype enemyArchetype, IPrimalStakes primalStakes, IDramaticQuestion dramaticQuestion)
    {
        return "Romance LogLine prompt contribution...";
    }

}