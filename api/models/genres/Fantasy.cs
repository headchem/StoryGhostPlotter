using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.Genres;

public class Fantasy : IGenre
{
    public string Id { get { return "fantasy"; } }
    public string Name { get { return "Fantasy"; } }
    public string Description { get { return "Fantasy typically involves magical elements, is set in a vaguely medieval universe, and is inspired by fantastical folklore myths."; } }
    public List<string> Keywords
    {
        get
        {
            return new List<string>{
                "magic", "wildness", "politics", "creatures", "legends"
            };
        }
    }

    public string GetLogLineContribution(long seed, IProblemTemplate problemTemplate, IArchetype heroArchetype, IArchetype enemyArchetype, IPrimalStakes primalStakes, IDramaticQuestion dramaticQuestion)
    {
        return $"This is an award winning fantasy tale full of magic which is inspired by fantastical folklore myths.";
    }

}