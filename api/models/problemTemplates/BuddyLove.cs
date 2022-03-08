using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.ProblemTemplates;

public class BuddyLove : IProblemTemplate
{
    public string Id { get { return "buddyLove"; } }
    public string Name { get { return "Buddy Love"; } }
    public string Description { get { return "An inadequate hero must overcome a problem with an unlikely and incongruent partner who makes up for the Hero's shortcomings in surprising ways."; } }
    public List<string> Keywords
    {
        get
        {
            return new List<string>{
                "deficient", "counterpart", "complication"
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
                    ThemeStated = "This is a relationship story in disguise.",
                    Setup = "The Hero and their Buddy/Enemy don't get along.",
                    IncitingIncident = "The permanent continuation of their relationship is threatened.",
                    FunAndGames = "Hero and Buddy/Enemy grow closer, oblivious to the flaws in their relationship.",
                    AllHopeIsLost = "Hero and Buddy/Enemy have a big fight and declare the relationship is over.",
                    BreakIntoThree = "Both Hero and Buddy/Enemy realize they are two halves of a whole, and they need to surrender their egos and repair the relationship.",
                    Climax = "Hero and Buddy/Enemy transform each other and create an even better relationship than they had before."
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
                HeroAdjective = "Inadequate",
                EnemyAdjective = "Capable"
            };
        }
    }

    public Adjectives WandererAdjectives
    {
        get
        {
            return new Adjectives
            {
                HeroAdjective = "Inadequate",
                EnemyAdjective = "Capable"
            };
        }
    }

    public Adjectives WarriorAdjectives
    {
        get
        {
            return new Adjectives
            {
                HeroAdjective = "Confident",
                EnemyAdjective = "Incapable"
            };
        }
    }

    public Adjectives MartyrAdjectives
    {
        get
        {
            return new Adjectives
            {
                HeroAdjective = "Confident",
                EnemyAdjective = "Capable"
            };
        }
    }

    public string GetCharacterStageContribution(long seed, string characterStage, IGenre genre, IDramaticQuestion dramaticQuestion)
    {
        return characterStage switch
        {
            "orphan" => "At this stage in the story, the main character and their buddy/enemy don't get along but are forced to interact.",
            "wanderer" => "At this stage in the story, the main character and their buddy/enemy grow closer, oblivious to the flaws in their relationship.",
            "warrior" => "At this stage in the story, the relationship between the main character and their buddy/enemy breaks down and they declare the relationship is over.",
            "martyr" => "At this stage in the story, the main character and their buddy/enemy realize they are two halves of a whole, and they need to surrender their egos and repair the relationship.",
            _ => throw new ArgumentException(message: "invalid completion type value", paramName: nameof(characterStage)),
        };
    }

}