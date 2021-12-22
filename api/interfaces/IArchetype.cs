using System;
using StoryGhost.Models;

namespace StoryGhost.Interfaces;

public interface IArchetype
{
    public string Id {get;}
    public string Name { get; }
    public string Description { get; }

    public string GetHeroLogLineContribution(IGenre genre, IProblemTemplate problemTemplate, IArchetype enemyArchetype, IPrimalStakes primalStakes, IDramaticQuestion dramaticQuestion);
    public string GetEnemyLogLineContribution(IGenre genre, IProblemTemplate problemTemplate, IArchetype heroArchetype, IPrimalStakes primalStakes, IDramaticQuestion dramaticQuestion);

}