using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.Genres;

public class Drama : IGenre
{
    public string Id { get { return "drama"; } }
    public string Name { get { return "Drama"; } }
    public string Description { get { return "Drama is the tension created between extreme forces that oppose one another. It focuses on some aspect of humanity and tests it to the extreme, revealing intense emotions and challenging the relationships of the characters involved."; } }
    public List<string> Keywords
    {
        get
        {
            return new List<string>{
                "conflict", "choice", "relatability", "opposites", "defeat", "triumph"
            };
        }
    }

    public string GetLogLineContribution(long seed, IProblemTemplate problemTemplate, IArchetype heroArchetype, IArchetype enemyArchetype, IPrimalStakes primalStakes, IDramaticQuestion dramaticQuestion)
    {
        return $"This is an award winning drama that reveals intense emotions as the characters are challenged by a problem and each other.";
    }

}