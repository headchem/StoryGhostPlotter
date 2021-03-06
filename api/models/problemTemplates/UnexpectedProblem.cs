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
                "innocence", "surprise", "survival"
            };
        }
    }

    public SequenceAdvices AdviceSequence
    {
        get
        {
            return new SequenceAdvices
            {
                Events = new AdviceSequence
                {
                    Setup = "The Hero is an ordinary person. The Enemy is larger than life.",
                    Midpoint = "The larger-than-life Enemy is forced to take notice of the ordinary Hero.",
                    AllHopeIsLost = "The Enemy reminds the ordinary Hero that they are powerless and should know their place.",
                    DarkNightOfTheSoul = "The Hero finds something within themselves - something every average person has - that might allow them to defeat the Enemy."
                },
                Context = new AdviceSequence
                {

                }
            };
        }
    }


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

    public string GetCharacterStageContribution(long seed, string characterStage, IGenre genre, IDramaticQuestion dramaticQuestion)
    {
        return characterStage switch
        {
            "orphan" => "At this stage in the story, the main character is an ordinary person faced with a larger-than-life problem.",
            "wanderer" => "At this stage in the story, the larger-than-life problem is forced to take notice of the ordinary main character.",
            "warrior" => "At this stage in the story, the larger-than-life problem reminds the ordinary main character that they are powerless and should know their place.",
            "martyr" => "At this stage in the story, the main character finds something within themselves - something every average person has - that allows them to overcome the problem.",
            _ => throw new ArgumentException(message: "invalid completion type value", paramName: nameof(characterStage)),
        };
    }

}