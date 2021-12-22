using System;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.ProblemTemplates;

public class BuddyLove : IProblemTemplate
{
    public string Id { get { return "buddyLove"; } }
    public string Name { get { return "Buddy Love"; } }
    public string Description { get { return "Buddy Love desc here"; } }

    public string GetLogLineContribution(IGenre genre, IArchetype heroArchetype, IArchetype enemyArchetype, IPrimalStakes primalStakes, IDramaticQuestion dramaticQuestion)
    {
        return "Buddy Love LogLine prompt contribution...";
    }

}