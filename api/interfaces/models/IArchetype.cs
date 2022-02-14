using System;
using System.Collections.Generic;
using StoryGhost.Models;

namespace StoryGhost.Interfaces;

public interface IArchetype
{
    public string Id { get; }
    public string Name { get; }
    public string Description { get; }
    public string SourceOfMotivation { get; }
    public List<string> GreatestFears { get; }
    public List<string> Talents { get; }
    public List<string> Weaknesses { get; }
    public string AddictiveQuality { get; }
    public List<string> Addictions { get; }
    public string ShadowSide { get; }
    public List<string> Examples { get; }
    public string Motto { get; }
    public string OrphanDesires { get; }
    public string WandererResponse { get; }
    public string WarriorResponse { get; }

    public AdviceSequence HeroAdviceSequence { get; }
    public AdviceSequence EnemyAdviceSequence { get; }

    
    public string GetHeroLogLineContribution(long seed, IGenre genre, IProblemTemplate problemTemplate, IArchetype enemyArchetype, IPrimalStakes primalStakes, IDramaticQuestion dramaticQuestion);
    public string GetEnemyLogLineContribution(long seed, IGenre genre, IProblemTemplate problemTemplate, IArchetype heroArchetype, IPrimalStakes primalStakes, IDramaticQuestion dramaticQuestion);
    public string GetCharacterStageContribution(long seed, string characterStage, IGenre genre, IProblemTemplate problemTemplate, IArchetype enemyArchetype, IPrimalStakes primalStakes, IDramaticQuestion dramaticQuestion);
}