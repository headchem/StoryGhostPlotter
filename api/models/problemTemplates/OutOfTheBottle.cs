using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.ProblemTemplates;

public class OutOfTheBottle : IProblemTemplate
{
    public string Id { get { return "outOfTheBottle"; } }
    public string Name { get { return "Out of the Bottle"; } }
    public string Description { get { return "A covetous hero is granted a supernatural blessing, but it's not what they really needed, and threatens to become a curse if left unchecked."; } }
    public List<string> Keywords
    {
        get
        {
            return new List<string>{
                "wish", "spell", "lesson"
            };
        }
    }

    public string OpeningImage { get { return ""; } }
    public string ThemeStated { get { return ""; } }
    public string Setup { get { return "The underdog Hero secretly makes a wish to the universe for some supernatural blessing."; } }
    public string IncitingIncident { get { return "The Hero's wish is actually fulfilled."; } }
    public string Debate { get { return "The Hero confirms the blessing is real by testing it."; } }
    public string BreakIntoTwo { get { return ""; } }
    public string FunAndGames { get { return ""; } }
    public string FirstPinchPoint { get { return ""; } }
    public string Midpoint { get { return ""; } }
    public string BadGuysCloseIn { get { return "The Hero feels entitled to their blessing and takes it for granted."; } }
    public string SecondPinchPoint { get { return ""; } }
    public string AllHopeIsLost { get { return "The Hero's blessing can't fix their flaws."; } }
    public string DarkNightOfTheSoul { get { return "The Hero admits they didn't need the blessing - what they really needed was to grow as a person."; } }
    public string BreakIntoThree { get { return "The Hero formulates a plan to defeat the Problem that doesn't rely on the blessing."; } }
    public string Climax { get { return ""; } }
    public string Cooldown { get { return ""; } }

public Adjectives OrphanAdjectives
    {
        get
        {
            return new Adjectives
            {
                HeroAdjective = "Covetous",
                EnemyAdjective = "Trickster"
            };
        }
    }

    public Adjectives WandererAdjectives
    {
        get
        {
            return new Adjectives
            {
                HeroAdjective = "Covetous",
                EnemyAdjective = "Trickster"
            };
        }
    }

    public Adjectives WarriorAdjectives
    {
        get
        {
            return new Adjectives
            {
                HeroAdjective = "Generous",
                EnemyAdjective = "Bored"
            };
        }
    }

    public Adjectives MartyrAdjectives
    {
        get
        {
            return new Adjectives
            {
                HeroAdjective = "Generous",
                EnemyAdjective = "Trickster"
            };
        }
    }

    public string GetLogLineContribution(int seed, IGenre genre, IArchetype heroArchetype, IArchetype enemyArchetype, IPrimalStakes primalStakes, IDramaticQuestion dramaticQuestion)
    {
        return $"This is a {Name} story about the ideas of: {string.Join(", ", Keywords)}.";
    }

}