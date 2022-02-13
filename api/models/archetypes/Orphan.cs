using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;
using StoryGhost.Enums;

namespace StoryGhost.Models.Archetypes;

public class Orphan : IArchetype
{
    public string Id { get { return "orphan"; } }
    public string Name { get { return "Orphan"; } }
    public string Description { get { return "The Orphan has metaphorically skipped childhood. They are unpretentious, street smart, and empathize with the struggle of others. They fear exploitation and being singled out from the crowd. They are prone to a victim mentality and must parent themselves."; } }
    public string SourceOfMotivation { get { return SourceOfMotivationEnum.Themselves; } }
    public string OrphanDesires { get { return "To belong, regain safety, connect with others."; } }
    public string WandererResponse { get { return "Be victimized by it."; } }
    public string WarriorResponse { get { return "Develop ordinary solid virtues, be down to earth, process and feel pain fully."; } }
    public List<string> GreatestFears
    {
        get
        {
            return new List<string>{
                "to be left out or to stand out from the crowd", "exploitation"
            };
        }
    }
    public List<string> Talents
    {
        get
        {
            return new List<string> {
                "realism", "empathy", "lack of pretense", "interdependence", "resilience"
            };
        }
    }
    public List<string> Weaknesses
    {
        get
        {
            return new List<string> {
                "suppressing true self to blend in or maintain superficial relationships", "cynicism", "tendency to be the victim", "chronic complaining"
            };
        }
    }
    public string AddictiveQuality { get { return "cynicism"; } }
    public List<string> Addictions
    {
        get
        {
            return new List<string>{
                "powerlessness", "worrying"
            };
        }
    }
    public string ShadowSide { get { return "The victim blames their predatory behavior and incompetence on others. They expect special treatment due to being fragile from past victimization. They attack people who are trying to help them, or collapse and become dysfunctional."; } }
    public List<string> Examples
    {
        get
        {
            return new List<string>{
                "down-to-earth person", "realist", "diligent worker", "solid citizen", "good neighbor"
            };
        }
    }
    public string Motto { get { return "All people are created equal."; } }


    public string OpeningImage { get { return ""; } }
    public string ThemeStated { get { return ""; } }
    public string Setup { get { return ""; } }
    public string IncitingIncident { get { return ""; } }
    public string Debate { get { return ""; } }
    public string BStory { get { return ""; } }
    public string BreakIntoTwo { get { return ""; } }
    public string FunAndGames { get { return ""; } }
    public string FirstPinchPoint { get { return ""; } }
    public string Midpoint { get { return ""; } }
    public string BadGuysCloseIn { get { return ""; } }
    public string SecondPinchPoint { get { return ""; } }
    public string AllHopeIsLost { get { return ""; } }
    public string DarkNightOfTheSoul { get { return ""; } }
    public string BreakIntoThree { get { return ""; } }
    public string Climax { get { return ""; } }
    public string Cooldown { get { return ""; } }


    public string GetHeroLogLineContribution(long seed, IGenre genre, IProblemTemplate problemTemplate, IArchetype enemyArchetype, IPrimalStakes primalStakes, IDramaticQuestion dramaticQuestion)
    {
        return $"The main character's personality is that of an {Name.ToLower()} (for example: {string.Join(", ", Examples)}).";
    }
    public string GetEnemyLogLineContribution(long seed, IGenre genre, IProblemTemplate problemTemplate, IArchetype heroArchetype, IPrimalStakes primalStakes, IDramaticQuestion dramaticQuestion)
    {
        return $"The personality of the secondary character (or antagonist) is that of an {Name.ToLower()} (for example: {string.Join(", ", Examples)}).";
    }

    public string GetCharacterStageContribution(long seed, string characterStage, IGenre genre, IProblemTemplate problemTemplate, IArchetype enemyArchetype, IPrimalStakes primalStakes, IDramaticQuestion dramaticQuestion)
    {
        return characterStage switch
        {
            "orphan" => $"The main character's only motivation is to belong, be in safety, and connect with others, while they interact with the theme of {dramaticQuestion.Name.ToLower()} by demonstrating {dramaticQuestion.Contrary.ToLower()}.",
            "wanderer" => $"The main character allows themselves to be victimized by the problem, while they interact with the theme of {dramaticQuestion.Name.ToLower()} by demonstrating {dramaticQuestion.Contradiction.ToLower()}.",
            "warrior" => $"While the main character is victimized by the problem, the problem continues to get worse. They interact with the theme of {dramaticQuestion.Name.ToLower()} by demonstrating {dramaticQuestion.Negation.ToLower()}.",
            "martyr" => $"Finally, the main character demonstrates {dramaticQuestion.Positive.ToLower()} and successfully handles the problem by developing ordinary solid virtues, being down to earth, and processing pain fully.",
            _ => throw new ArgumentException(message: "invalid completion type value", paramName: nameof(characterStage)),
        };
    }
}