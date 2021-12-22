using System;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.ProblemTemplates;

public class FoolTriumphant : IProblemTemplate
{
    public string Id { get { return "foolTriumphant"; } }
    public string Name { get { return "Fool Triumphant"; } }
    public string Description { get { return "Fool Triumphant desc here"; } }

    public string GetLogLineContribution(IGenre genre, IArchetype heroArchetype, IArchetype enemyArchetype, IPrimalStakes primalStakes, IDramaticQuestion dramaticQuestion)
    {
        return "Fool Triumphant LogLine prompt contribution...";
    }

}