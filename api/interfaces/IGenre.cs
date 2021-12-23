using System;
using StoryGhost.Models;

namespace StoryGhost.Interfaces;

public interface IGenre
{
    public string Id { get; }
    public string Name { get; }
    public string Description { get; }

    public string GetLogLineContribution(IProblemTemplate problemTemplate, IArchetype heroArchetype, IArchetype enemyArchetype, IPrimalStakes primalStakes, IDramaticQuestion dramaticQuestion);
}