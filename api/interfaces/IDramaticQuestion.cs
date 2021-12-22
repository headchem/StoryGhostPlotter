using System;
using StoryGhost.Models;

namespace StoryGhost.Interfaces;

public interface IDramaticQuestion
{
    public string Id {get;}
    public string Name { get; }
    public string Description { get; }

    public string GetLogLineContribution(IGenre genre, IProblemTemplate problemTemplate, IArchetype heroArchetype, IArchetype enemyArchetype, IPrimalStakes primalStakes);
}