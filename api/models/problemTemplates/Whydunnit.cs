using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.ProblemTemplates;

public class Whydunnit : IProblemTemplate
{
    public string Id { get { return "whydunnit"; } }
    public string Name { get { return "Whydunnit"; } }
    public string Description { get { return "An obsessive hero must know the \"why\" behind a mystery before they are engulfed by the evil they seek to understand."; } }
    public List<string> Keywords
    {
        get
        {
            return new List<string>{
                "detective", "secret", "dark turn"
            };
        }
    }

    public string OpeningImage { get { return ""; } }
    public string ThemeStated { get { return ""; } }
    public string Setup { get { return ""; } }
    public string IncitingIncident { get { return "An unknown and unseen Enemy commits a crime."; } }
    public string Debate { get { return "Due to personal reasons, the Hero is reluctant to dedicate themselves to investigating."; } }
    public string BreakIntoTwo { get { return "The Hero can't shake the obsession of needing to know why the crime was committed."; } }
    public string FunAndGames { get { return ""; } }
    public string FirstPinchPoint { get { return ""; } }
    public string Midpoint { get { return "The Hero thinks they have found who committed the crime."; } }
    public string BadGuysCloseIn { get { return "The Hero is unsatisfied with the answer of why the presumed culprit committed the crime."; } }
    public string SecondPinchPoint { get { return ""; } }
    public string AllHopeIsLost { get { return "The crime goes much deeper than the Hero realized - Every discovery they had made now appears irrelevant."; } }
    public string DarkNightOfTheSoul { get { return "The Hero realizes they are not so different from the Enemy."; } }
    public string BreakIntoThree { get { return ""; } }
    public string Climax { get { return ""; } }
    public string Cooldown { get { return ""; } }

public Adjectives OrphanAdjectives
    {
        get
        {
            return new Adjectives
            {
                HeroAdjective = "Obesessed",
                EnemyAdjective = "Evasive"
            };
        }
    }

    public Adjectives WandererAdjectives
    {
        get
        {
            return new Adjectives
            {
                HeroAdjective = "Obesessed",
                EnemyAdjective = "Evasive"
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
                EnemyAdjective = "Tempting"
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
                EnemyAdjective = "Evasive"
            };
        }
    }

    public string GetCharacterStageContribution(int seed, string characterStage, IGenre genre, IArchetype heroArchetype, IArchetype enemyArchetype, IPrimalStakes primalStakes, IDramaticQuestion dramaticQuestion)
    {
        return $"This is a {Name} story about the ideas of: {string.Join(", ", Keywords)}.";
    }

}