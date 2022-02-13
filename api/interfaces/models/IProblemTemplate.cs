using System;
using System.Collections.Generic;
using StoryGhost.Models.ProblemTemplates;

namespace StoryGhost.Interfaces;

public interface IProblemTemplate
{
    public string Id { get; }
    public string Name { get; }
    public string Description { get; }
    public List<string> Keywords { get; }

    public string OpeningImage { get; }
    public string ThemeStated { get; }
    public string Setup { get; }
    public string IncitingIncident { get; }
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

    public Adjectives OrphanAdjectives { get; }
    public Adjectives WandererAdjectives { get; }
    public Adjectives WarriorAdjectives { get; }
    public Adjectives MartyrAdjectives { get; }


    public string GetCharacterStageContribution(long seed, string characterStage, IGenre genre, IArchetype heroArchetype, IArchetype enemyArchetype, IPrimalStakes primalStakes, IDramaticQuestion dramaticQuestion);
}