using System;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.Archetypes;

public class Caregiver : IArchetype
{
    public string Id { get { return "caregiver"; } }
    public string Name { get { return "Caregiver"; } }
    public string Description { get { return "Caregiver desc goes here"; } }

    public string GetHeroLogLineContribution(IGenre genre, IProblemTemplate problemTemplate, IArchetype enemyArchetype, IPrimalStakes primalStakes, IDramaticQuestion dramaticQuestion)
    {
        return "Caregiver LogLine prompt contribution for Hero";
    }
    public string GetEnemyLogLineContribution(IGenre genre, IProblemTemplate problemTemplate, IArchetype heroArchetype, IPrimalStakes primalStakes, IDramaticQuestion dramaticQuestion)
    {
        return "Caregiver LogLine prompt contribution for Enemy";
    }

}