using System;
using StoryGhost.Models;

namespace StoryGhost.Interfaces;

public interface IProblemTemplate
{
    public string Id {get;}
    public string Name { get; }
    public string Description { get; }

    public string GetLogLineContribution(IGenre genre, IArchetype heroArchetype, IArchetype enemyArchetype, IPrimalStakes primalStakes, IDramaticQuestion dramaticQuestion);
}