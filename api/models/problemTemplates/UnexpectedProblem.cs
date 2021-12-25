using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.ProblemTemplates;

public class UnexpectedProblem : IProblemTemplate
{
    public string Id { get { return "unexpectedProblem"; } }
    public string Name { get { return "Unexpected Problem"; } }
    public string Description { get { return "An unwitting hero must survive after being unexpectedly forced into a dangerous situation they can't escape."; } }
    public List<string> Keywords
    {
        get
        {
            return new List<string>{
                "Innocence", "Surprise", "Survival"
            };
        }
    }

    public string OpeningImage { get { return ""; } }
    public string ThemeStated { get { return ""; } }
    public string Setup { get { return "The Hero is an ordinary person. The Enemy is larger than life."; } }
    public string IncitingIncident { get { return ""; } }
    public string Debate { get { return ""; } }
    public string BreakIntoTwo { get { return ""; } }
    public string FunAndGames { get { return ""; } }
    public string FirstPinchPoint { get { return ""; } }
    public string Midpoint { get { return "The larger-than-life Enemy is forced to take notice of the ordinary Hero."; } }
    public string BadGuysCloseIn { get { return ""; } }
    public string SecondPinchPoint { get { return ""; } }
    public string AllHopeIsLost { get { return "The Enemy reminds the ordinary Hero that they are powerless and should know their place."; } }
    public string DarkNightOfTheSoul { get { return "The Hero finds something within themselves - something every average person has - that might allow them to defeat the Enemy."; } }
    public string BreakIntoThree { get { return ""; } }
    public string Climax { get { return ""; } }
    public string Cooldown { get { return ""; } }

public Adjectives OrphanAdjectives
    {
        get
        {
            return new Adjectives
            {
                HeroAdjective = "Unwitting",
                EnemyAdjective = "Indifferent"
            };
        }
    }

    public Adjectives WandererAdjectives
    {
        get
        {
            return new Adjectives
            {
                HeroAdjective = "Unwitting",
                EnemyAdjective = "Indifferent"
            };
        }
    }

    public Adjectives WarriorAdjectives
    {
        get
        {
            return new Adjectives
            {
                HeroAdjective = "Controlling",
                EnemyAdjective = "Resisting"
            };
        }
    }

    public Adjectives MartyrAdjectives
    {
        get
        {
            return new Adjectives
            {
                HeroAdjective = "Controlling",
                EnemyAdjective = "Indifferent"
            };
        }
    }

    public string GetLogLineContribution(int seed, IGenre genre, IArchetype heroArchetype, IArchetype enemyArchetype, IPrimalStakes primalStakes, IDramaticQuestion dramaticQuestion)
    {
        return $"This is a {Name} story about the ideas of: {string.Join(", ", Keywords)}.";
    }

}