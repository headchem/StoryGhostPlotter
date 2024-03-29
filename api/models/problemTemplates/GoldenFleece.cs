using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.ProblemTemplates;

public class GoldenFleece : IProblemTemplate
{
    public string Id { get { return "goldenFleece"; } }
    public string Name { get { return "Golden Fleece"; } }
    public string Description { get { return "A driven hero leads allies to acquire what they desire through a perilous journey that turns out wildly different from the Heros's expectations."; } }
    public List<string> Keywords
    {
        get
        {
            return new List<string>{
                "journey", "team", "prize"
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
                    BreakIntoTwo = "The Hero goes \"on the road\" with a naive understanding of the destination they think they want to reach.",
                    FunAndGames = "Seemingly disconnected episodes each help the Hero grow, even if little progress is made on the \"road\".",
                    DarkNightOfTheSoul = "The Hero realizes what they really desired was their own personal growth.",
                    BreakIntoThree = "Fully leveraging how the Hero has grown, a plan is hatched to attain the original desire."
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
                HeroAdjective = "Driven",
                EnemyAdjective = "Greedy"
            };
        }
    }

    public Adjectives WandererAdjectives
    {
        get
        {
            return new Adjectives
            {
                HeroAdjective = "Driven",
                EnemyAdjective = "Greedy"
            };
        }
    }

    public Adjectives WarriorAdjectives
    {
        get
        {
            return new Adjectives
            {
                HeroAdjective = "Yielding",
                EnemyAdjective = "Generous"
            };
        }
    }

    public Adjectives MartyrAdjectives
    {
        get
        {
            return new Adjectives
            {
                HeroAdjective = "Yielding",
                EnemyAdjective = "Greedy"
            };
        }
    }

    public string GetCharacterStageContribution(long seed, string characterStage, IGenre genre, IDramaticQuestion dramaticQuestion)
    {
        return characterStage switch
        {
            "orphan" => "At this stage in the story, the main character goes on a journey with a naive understanding of the destination they think they want to reach.",
            "wanderer" => "At this stage in the story, seemingly disconnected episodes each help the main character grow.",
            "warrior" => "At this stage in the story, the main character realizes the real treasure is their own personal growth.",
            "martyr" => "At this stage in the story, the main character fully leverages their personal growth to attain the original prize they first sought.",
            _ => throw new ArgumentException(message: "invalid completion type value", paramName: nameof(characterStage)),
        };
    }

}