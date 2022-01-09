using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.PrimalStakes;

public class FindConnection : IPrimalStakes
{
    public string Id { get { return "findConnection"; } }
    public string Name { get { return "find connection"; } }
    public string Description { get { return "The Hero lacks a deep connection in life, and they are irresistably drawn to another entity that is seemingly incompatible. As the two learn more about each other, they develop a strong bond."; } }
    public List<string> Keywords
    {
        get
        {
            return new List<string>{
                "loneliness", "rescue", "connection", "passion", "belonging"
            };
        }
    }

    public string GetLogLineContribution(int seed, IGenre genre, IProblemTemplate problemTemplate, IArchetype heroArchetype, IArchetype enemyArchetype, IDramaticQuestion dramaticQuestion)
    {
        return $"This story eventually ends with the main character finding emotional connection.";
    }

}