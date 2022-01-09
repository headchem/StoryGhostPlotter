using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.ProblemTemplates;

public class Superhero : IProblemTemplate
{
    public string Id { get { return "superhero"; } }
    public string Name { get { return "Superhero"; } }
    public string Description { get { return "A gifted hero must defeat a stronger Enemy by using the same powers that disconnect them from those they save."; } }
    public List<string> Keywords
    {
        get
        {
            return new List<string>{
                "special power", "nemesis", "curse"
            };
        }
    }

    public string OpeningImage { get { return ""; } }
    public string ThemeStated { get { return ""; } }
    public string Setup { get { return "The extraordinary Hero finds themselves in an ordinary world, surrounded by tiny minds."; } }
    public string IncitingIncident { get { return "A tiny-minded Enemy is jealous and afraid of the Hero's powers. The Hero is misunderstood and feels shunned."; } }
    public string Debate { get { return ""; } }
    public string BreakIntoTwo { get { return ""; } }
    public string FunAndGames { get { return ""; } }
    public string FirstPinchPoint { get { return ""; } }
    public string Midpoint { get { return "The tiny-minded Enemy begrudgingly acknowledges the Hero's extraordinary powers."; } }
    public string BadGuysCloseIn { get { return ""; } }
    public string SecondPinchPoint { get { return ""; } }
    public string AllHopeIsLost { get { return "The Hero is unappreciated and betrayed by those they respected and trusted."; } }
    public string DarkNightOfTheSoul { get { return "The Hero realizes they have a responsibility to use their powers to do what is right, even if they are forever shunned."; } }
    public string BreakIntoThree { get { return ""; } }
    public string Climax { get { return "The Hero attains acceptance and appreciation for saving an undeserving world."; } }
    public string Cooldown { get { return ""; } }

public Adjectives OrphanAdjectives
    {
        get
        {
            return new Adjectives
            {
                HeroAdjective = "Wreckless",
                EnemyAdjective = "Tyrannizing"
            };
        }
    }

    public Adjectives WandererAdjectives
    {
        get
        {
            return new Adjectives
            {
                HeroAdjective = "Wreckless",
                EnemyAdjective = "Tyrannizing"
            };
        }
    }

    public Adjectives WarriorAdjectives
    {
        get
        {
            return new Adjectives
            {
                HeroAdjective = "Judicious",
                EnemyAdjective = "Judicious"
            };
        }
    }

    public Adjectives MartyrAdjectives
    {
        get
        {
            return new Adjectives
            {
                HeroAdjective = "Judicious",
                EnemyAdjective = "Tyrannizing"
            };
        }
    }

    public string GetCharacterStageContribution(int seed, string characterStage, IGenre genre, IArchetype heroArchetype, IArchetype enemyArchetype, IPrimalStakes primalStakes, IDramaticQuestion dramaticQuestion)
    {
        return $"This is a {Name} story about the ideas of: {string.Join(", ", Keywords)}.";
    }

}