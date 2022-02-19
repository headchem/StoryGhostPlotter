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

    public AdviceSequence AdviceSequence
    {
        get
        {
            return new AdviceSequence
            {
                IncitingIncident = "An suspicious entity plans or commits a crime.",
                Debate = "Due to personal reasons, the Hero is reluctant to dedicate themselves to investigating.",
                BreakIntoTwo = "The Hero can't shake the obsession of needing to know why the crime was committed.",
                Midpoint = "The Hero thinks they have found who committed the crime.",
                BadGuysCloseIn = "The Hero is unsatisfied with the answer of why the presumed culprit committed the crime.",
                AllHopeIsLost = "The crime goes much deeper than the Hero realized - Every discovery they had made now appears irrelevant.",
                DarkNightOfTheSoul = "The Hero realizes they are not so different from the Enemy."
            };
        }
    }


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

    public string GetCharacterStageContribution(long seed, string characterStage, IGenre genre, IArchetype heroArchetype, IArchetype enemyArchetype, IPrimalStakes primalStakes, IDramaticQuestion dramaticQuestion)
    {
        return characterStage switch
        {
            "orphan" => "At this stage in the story, an unknown enemy commits a crime and the main character can't shake the obsession of needing to know why the crime was committed.",
            "wanderer" => "At this stage in the story, the main character thinks they have found the culprit, but they are unsatisfied with the reason the crime was committed.",
            "warrior" => "At this stage in the story, the main character discovers the crime goes much deeper than realized, making previous discoveries appear irrelevant.",
            "martyr" => "At this stage in the story, the main character realizes they are not so different from the enemy, and uses this insight to uncover the truth.",
            _ => throw new ArgumentException(message: "invalid completion type value", paramName: nameof(characterStage)),
        };
    }

}