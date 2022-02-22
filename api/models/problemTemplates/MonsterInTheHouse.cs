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

    public AdviceSequence AdviceSequence
    {
        get
        {
            return new AdviceSequence
            {
                Setup = "Both Hero and Enemy are confined to a small space, forcing them to interact.",
                IncitingIncident = "The Hero commits a sin that results in the awakening of a monster.",
                DarkNightOfTheSoul = "The Hero realizes the sin they committed and repents.",
                Climax = "The monster vanquishes those who have sinned, but spares those who have repented."
            };
        }
    }


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

    public string GetCharacterStageContribution(long seed, string characterStage, IGenre genre, IDramaticQuestion dramaticQuestion)
    {
        return characterStage switch
        {
            "orphan" => "At this stage in the story, the main character and enemy are confined together, and the main character commits a \"sin\" which awakens a \"monster\".",
            "wanderer" => "At this stage in the story, the main character thinks they can outwit or placate the \"monster\".",
            "warrior" => "At this stage in the story, the main character realizes the \"sin\" they committed and repents.",
            "martyr" => "At this stage in the story, the \"monster\" vanquishes those who have sinned, but spares the main character, who has repented.",
            _ => throw new ArgumentException(message: "invalid completion type value", paramName: nameof(characterStage)),
        };
    }

}