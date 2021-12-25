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

    public string OrphanDesires { get { return "Protect and care for others."; } }
    public string WandererResponse { get { return "Stop the problem, or shield and care for those it harms."; } }
    public string WarriorResponse { get { return "Help without maiming self or others."; } }


    public string GetHeroLogLineContribution(int seed, IGenre genre, IProblemTemplate problemTemplate, IArchetype enemyArchetype, IPrimalStakes primalStakes, IDramaticQuestion dramaticQuestion)
    {
        return $"HERO has a caregiver personality (for example: {string.Join(", ", Examples)}).";
    }
    public string GetEnemyLogLineContribution(int seed, IGenre genre, IProblemTemplate problemTemplate, IArchetype heroArchetype, IPrimalStakes primalStakes, IDramaticQuestion dramaticQuestion)
    {
        return $"ENEMY has a caregiver personality (for example: {string.Join(", ", Examples)}).";
    }

}