using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.ProblemTemplates;

public class MonsterInTheHouse : IProblemTemplate
{
    public string Id { get { return "monsterInTheHouse"; } }
    public string Name { get { return "Monster in the House"; } }
    public string Description { get { return "A blameworthy hero is forced to protect a trapped group of allies from being consumed by a monster the Hero accidentally created."; } }
    public List<string> Keywords
    {
        get
        {
            return new List<string>{
                "monster", "confined space", "sin"
            };
        }
    }

    public string OpeningImage { get { return ""; } }
    public string ThemeStated { get { return ""; } }
    public string Setup { get { return "Both Hero and Enemy are confined to a small space, forcing them to interact."; } }
    public string IncitingIncident { get { return "The Hero commits a sin that results in the awakening of a monster."; } }
    public string Debate { get { return ""; } }
    public string BreakIntoTwo { get { return ""; } }
    public string FunAndGames { get { return ""; } }
    public string FirstPinchPoint { get { return ""; } }
    public string Midpoint { get { return ""; } }
    public string BadGuysCloseIn { get { return ""; } }
    public string SecondPinchPoint { get { return ""; } }
    public string AllHopeIsLost { get { return ""; } }
    public string DarkNightOfTheSoul { get { return "The Hero realizes the sin they committed and repents."; } }
    public string BreakIntoThree { get { return ""; } }
    public string Climax { get { return "The monster vanquishes those who have sinned, but spares those who have repented."; } }
    public string Cooldown { get { return ""; } }

public Adjectives OrphanAdjectives
    {
        get
        {
            return new Adjectives
            {
                HeroAdjective = "Blameworthy",
                EnemyAdjective = "Rageful"
            };
        }
    }

    public Adjectives WandererAdjectives
    {
        get
        {
            return new Adjectives
            {
                HeroAdjective = "Blameworthy",
                EnemyAdjective = "Rageful"
            };
        }
    }

    public Adjectives WarriorAdjectives
    {
        get
        {
            return new Adjectives
            {
                HeroAdjective = "Responsible",
                EnemyAdjective = "Fearful"
            };
        }
    }

    public Adjectives MartyrAdjectives
    {
        get
        {
            return new Adjectives
            {
                HeroAdjective = "Responsible",
                EnemyAdjective = "Rageful"
            };
        }
    }

    public string GetLogLineContribution(int seed, IGenre genre, IArchetype heroArchetype, IArchetype enemyArchetype, IPrimalStakes primalStakes, IDramaticQuestion dramaticQuestion)
    {
        return $"This is a {Name} story about the ideas of: {string.Join(", ", Keywords)}.";
    }

}