using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.Genres;

public class Adventure : IGenre
{
    public string Id { get { return "adventure"; } }
    public string Name { get { return "Adventure"; } }
    public string Description { get { return "Adventure is a face-paced tale where the Hero is in a risky situation. Typically involving a difficult quest, the Hero makes numerous discoveries and encounters dangers at every step."; } }
    public List<string> Keywords
    {
        get
        {
            return new List<string>{
                "danger", "excitement", "action", "travel", "quests", "discovery"
            };
        }
    }

    public string GetLogLineContribution(int seed, IProblemTemplate problemTemplate, IArchetype heroArchetype, IArchetype enemyArchetype, IPrimalStakes primalStakes, IDramaticQuestion dramaticQuestion)
    {
        return "Adventure LogLine prompt contribution...";
    }

}