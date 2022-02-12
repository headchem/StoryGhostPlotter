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

    public string OpeningImage { get; }
    public string ThemeStated { get; }
    public string Setup { get; }
    public string IncitingIncident { get; }
    public string BStory { get; }
    public string Debate { get; }
    public string BreakIntoTwo { get; }
    public string FunAndGames { get; }
    public string FirstPinchPoint { get; }
    public string Midpoint { get; }
    public string BadGuysCloseIn { get; }
    public string SecondPinchPoint { get; }
    public string AllHopeIsLost { get; }
    public string DarkNightOfTheSoul { get; }
    public string BreakIntoThree { get; }
    public string Climax { get; }
    public string Cooldown { get; }

    public string GetHeroLogLineContribution(long seed, IGenre genre, IProblemTemplate problemTemplate, IArchetype enemyArchetype, IPrimalStakes primalStakes, IDramaticQuestion dramaticQuestion);
    public string GetEnemyLogLineContribution(long seed, IGenre genre, IProblemTemplate problemTemplate, IArchetype heroArchetype, IPrimalStakes primalStakes, IDramaticQuestion dramaticQuestion);
    public string GetCharacterStageContribution(long seed, string characterStage, IGenre genre, IProblemTemplate problemTemplate, IArchetype enemyArchetype, IPrimalStakes primalStakes, IDramaticQuestion dramaticQuestion);
}