using System;
using System.Collections.Generic;
using StoryGhost.Models;

namespace StoryGhost.Interfaces;

public interface IPrimalStakes
{
    public string Id { get; }
    public string Name { get; }
    public string Description { get; }
    public List<string> Keywords { get; }

    public AdviceSequence AdviceSequence { get; }

    public string GetCharacterStageContribution(long seed, string characterStage, IGenre genre, IProblemTemplate problemTemplate, IArchetype heroArchetype, IArchetype enemyArchetype, IDramaticQuestion dramaticQuestion);

}