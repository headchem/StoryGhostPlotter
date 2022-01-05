using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.ProblemTemplates;

public class BuddyLove : IProblemTemplate
{
    public string Id { get { return "buddyLove"; } }
    public string Name { get { return "Buddy Love"; } }
    public string Description { get { return "An inadequate hero must overcome a problem with an unlikely and incongruent partner who makes up for the Hero's shortcomings in surprising ways."; } }
    public List<string> Keywords
    {
        get
        {
            return new List<string>{
                "deficient", "counterpart", "complication"
            };
        }
    }

    public string OpeningImage { get { return ""; } }
    public string ThemeStated { get { return "This is a love story in disguise."; } }
    public string Setup { get { return "The Hero and their Buddy/Enemy don't get along."; } }
    public string IncitingIncident { get { return "The permanent continuation of their relationship is threatened."; } }
    public string Debate { get { return ""; } }
    public string BreakIntoTwo { get { return ""; } }
    public string FunAndGames { get { return "Hero and Buddy/Enemy grow closer, oblivious to the flaws in their relationship."; } }
    public string FirstPinchPoint { get { return ""; } }
    public string Midpoint { get { return ""; } }
    public string BadGuysCloseIn { get { return ""; } }
    public string SecondPinchPoint { get { return ""; } }
    public string AllHopeIsLost { get { return "Hero and Buddy/Enemy have a big fight and declare the relationship is over."; } }
    public string DarkNightOfTheSoul { get { return ""; } }
    public string BreakIntoThree { get { return "Both Hero and Buddy/Enemy realize they are two halves of a whole, and they need to surrender their egos and repair the relationship."; } }
    public string Climax { get { return "Hero and Buddy/Enemy transform each other and create an even better relationship than they had before."; } }
    public string Cooldown { get { return ""; } }

    public Adjectives OrphanAdjectives
    {
        get
        {
            return new Adjectives
            {
                HeroAdjective = "Inadequate",
                EnemyAdjective = "Capable"
            };
        }
    }

    public Adjectives WandererAdjectives
    {
        get
        {
            return new Adjectives
            {
                HeroAdjective = "Inadequate",
                EnemyAdjective = "Capable"
            };
        }
    }

    public Adjectives WarriorAdjectives
    {
        get
        {
            return new Adjectives
            {
                HeroAdjective = "Confident",
                EnemyAdjective = "Incapable"
            };
        }
    }

    public Adjectives MartyrAdjectives
    {
        get
        {
            return new Adjectives
            {
                HeroAdjective = "Confident",
                EnemyAdjective = "Capable"
            };
        }
    }

    public string GetLogLineContribution(int seed, IGenre genre, IArchetype heroArchetype, IArchetype enemyArchetype, IPrimalStakes primalStakes, IDramaticQuestion dramaticQuestion)
    {
        return $"This is a {Name} story about the ideas of: {string.Join(", ", Keywords)}.";
    }

}