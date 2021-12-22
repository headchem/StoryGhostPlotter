using System;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.Archetypes;

public class Creator: IArchetype
{
    public string Id { get { return "creator"; } }
    public string Name { get { return "Creator"; } }
    public string Description { get { return "Creator desc here"; } }

    public string GetHeroLogLineContribution(IGenre genre, IProblemTemplate problemTemplate, IArchetype enemyArchetype, IPrimalStakes primalStakes, IDramaticQuestion dramaticQuestion)
    {
        return "Creator LogLine prompt contribution for Hero";
    }
    public string GetEnemyLogLineContribution(IGenre genre, IProblemTemplate problemTemplate, IArchetype heroArchetype, IPrimalStakes primalStakes, IDramaticQuestion dramaticQuestion)
    {
        return "Creator LogLine prompt contribution for Enemy";
    }
}