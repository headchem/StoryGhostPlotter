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

    public AdviceSequence AdviceSequence
    {
        get
        {
            return new AdviceSequence
            {
                Setup = "The extraordinary Hero finds themselves in an ordinary world, surrounded by tiny minds.",
                IncitingIncident = "A tiny-minded Enemy is jealous and afraid of the Hero's powers. The Hero is misunderstood and feels shunned.",
                Midpoint = "The tiny-minded Enemy begrudgingly acknowledges the Hero's extraordinary powers.",
                AllHopeIsLost = "The Hero is unappreciated and betrayed by those they respected and trusted.",
                DarkNightOfTheSoul = "The Hero realizes they have a responsibility to use their powers to do what is right, even if they are forever shunned.",
                Climax = "The Hero attains acceptance and appreciation for saving an undeserving world."
            };
        }
    }


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

    public string GetCharacterStageContribution(long seed, string characterStage, IGenre genre, IDramaticQuestion dramaticQuestion)
    {
        return characterStage switch
        {
            "orphan" => "At this stage in the story, the extraordinary main character finds themselves in an ordinary world, and they feel misunderstood and shunned.",
            "wanderer" => "At this stage in the story, the main character demonstrates their power by fighting back, and the enemy begrudgingly acknowledges their power.",
            "warrior" => "At this stage in the story, the main character is unappreciated and betrayed, but they accept the responsibility to use their powers to do what is right, even if they are forever shunned.",
            "martyr" => "At this stage in the story, the main character attains acceptance and appreciation for saving an undeserving world.",
            _ => throw new ArgumentException(message: "invalid completion type value", paramName: nameof(characterStage)),
        };
    }

}