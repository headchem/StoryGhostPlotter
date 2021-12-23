using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.ProblemTemplates;

public class BuddyLove : IProblemTemplate
{
    public string Id { get { return "buddyLove"; } }
    public string Name { get { return "Buddy Love"; } }
    public string Description { get { return "An inadequate hero must overcome a problem with an unlikely and incongruent partner who makes up for the Hero's shortcomings in surprising ways."; } }
    public List<string> Keywords
    {
        get
        {
            return new List<string>{
        "Deficient", "Counterpart", "Complication"
    };
        }
    }

    public string GetLogLineContribution(IGenre genre, IArchetype heroArchetype, IArchetype enemyArchetype, IPrimalStakes primalStakes, IDramaticQuestion dramaticQuestion)
    {
        return "Buddy Love LogLine prompt contribution...";
    }

}