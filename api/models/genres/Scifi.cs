using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.Genres;

public class Scifi : IGenre
{
    public string Id { get { return "scifi"; } }
    public string Name { get { return "Scifi"; } }
    public string Description { get { return "Scifi is packed full of futuristic ideas, extrapolating from what's possible today into advanced science and technology. It examines the consequences of these innovations, and seeks to inspire a sense of forward-thinking wonder."; } }
    public List<string> Keywords
    {
        get
        {
            return new List<string>{
                "technology", "future", "space", "aliens", "innovation"
            };
        }
    }

    public string GetLogLineContribution(int seed, IProblemTemplate problemTemplate, IArchetype heroArchetype, IArchetype enemyArchetype, IPrimalStakes primalStakes, IDramaticQuestion dramaticQuestion)
    {
        return $"This is an award winning scifi story full of futuristic concepts in science and technology.";
    }

}