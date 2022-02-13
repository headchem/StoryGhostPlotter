using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;
using StoryGhost.Enums;

namespace StoryGhost.Models.Archetypes;

public class Caregiver : IArchetype
{
    public string Id { get { return "caregiver"; } }
    public string Name { get { return "Caregiver"; } }
    public string Description { get { return "The Caregiver is generous, altruistic, compassionate, and selfless. They are prone to enabling bad behavior in others, and hurting themselves in pursuit of helping. They fear being selfish or ingrateful. They are addicted to rescuing and codependence."; } }
    public string SourceOfMotivation { get { return SourceOfMotivationEnum.Themselves; } }
    public string OrphanDesires { get { return "Protect and care for others."; } }
    public string WandererResponse { get { return "Stop the problem, or shield and care for those it harms."; } }
    public string WarriorResponse { get { return "Help without maiming self or others."; } }
    public List<string> GreatestFears
    {
        get
        {
            return new List<string>{
                "Be selfish or ingrateful"
            };
        }
    }
    public List<string> Talents
    {
        get
        {
            return new List<string> {
                "compassion", "generosity", "nurturance", "community"
            };
        }
    }
    public List<string> Weaknesses
    {
        get
        {
            return new List<string> {
                "forced to martyrdom and being exploited", "enabling others", "codependence", "guilt-tripping"
            };
        }
    }
    public string AddictiveQuality { get { return "rescuing"; } }
    public List<string> Addictions
    {
        get
        {
            return new List<string>{
                "caretaking", "codependence"
            };
        }
    }
    public string ShadowSide { get { return "The Caretaker is prone to controling those they help by making them feel guilty. They compulsively rescue, manipulating and smothering those they rescue."; } }
    public List<string> Examples
    {
        get
        {
            return new List<string>{
                "saint", "altruist", "parent", "helper", "supporter"
            };
        }
    }
    public string Motto { get { return "Love your neighbour as yourself"; } }

    
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
        return $"The main character's personality is that of a {Name.ToLower()} (for example: {string.Join(", ", Examples)}).";
    }
    public string GetEnemyLogLineContribution(long seed, IGenre genre, IProblemTemplate problemTemplate, IArchetype heroArchetype, IPrimalStakes primalStakes, IDramaticQuestion dramaticQuestion)
    {
        return $"The personality of the secondary character (or antagonist) is that of a {Name.ToLower()} (for example: {string.Join(", ", Examples)}).";
    }

    public string GetCharacterStageContribution(long seed, string characterStage, IGenre genre, IProblemTemplate problemTemplate, IArchetype enemyArchetype, IPrimalStakes primalStakes, IDramaticQuestion dramaticQuestion)
    {
        return characterStage switch
        {
            "orphan" => $"The main character's only motivation is to protect and care for others, while they interact with the theme of {dramaticQuestion.Name.ToLower()} by demonstrating {dramaticQuestion.Contrary.ToLower()}.",
            "wanderer" => $"The main character attempts to stop the problem, and shield those it harms, while they interact with the theme of {dramaticQuestion.Name.ToLower()} by demonstrating {dramaticQuestion.Contradiction.ToLower()}.",
            "warrior" => $"Despite the main character's efforts to protect others, the problem persists. They interact with the theme of {dramaticQuestion.Name.ToLower()} by demonstrating {dramaticQuestion.Negation.ToLower()}.",
            "martyr" => $"Finally, the main character demonstrates {dramaticQuestion.Positive.ToLower()} and successfully handles the problem without harming themselves or others.",
            _ => throw new ArgumentException(message: "invalid completion type value", paramName: nameof(characterStage)),
        };
    }

}