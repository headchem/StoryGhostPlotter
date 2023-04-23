using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.ProblemTemplates;

public class RitesOfPassage : IProblemTemplate
{
    public string Id { get { return "ritesOfPassage"; } }
    public string Name { get { return "Rites of Passage"; } }
    public string Description { get { return "A troubled hero must rise above an external crisis by defeating their own inner demons."; } }
    public List<string> Keywords
    {
        get
        {
            return new List<string>{
                "life problem", "wrong way", "acceptance"
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
                    ThemeStated = "It is hinted that a vague outside force will bring pain and torment the Hero.",
                    IncitingIncident = "The outside force brings misery and misfortune upon the Hero, and the Hero struggles to name it.",
                    FunAndGames = "The unseen force continues to sneak up on the Hero, while the beleaguered Hero is distracted with shallower problems.",
                    Midpoint = "The Hero temporarily contains the invisible force, and falsely believes they are in control.",
                    Climax = "The Hero is victorious by accepting their own humanity, surrendering and being at peace with the invisible forces of life they can't control."
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
                HeroAdjective = "Troubled",
                EnemyAdjective = "Doubtful"
            };
        }
    }

    public Adjectives WandererAdjectives
    {
        get
        {
            return new Adjectives
            {
                HeroAdjective = "Troubled",
                EnemyAdjective = "Doubtful"
            };
        }
    }

    public Adjectives WarriorAdjectives
    {
        get
        {
            return new Adjectives
            {
                HeroAdjective = "Successful",
                EnemyAdjective = "Hopeful"
            };
        }
    }

    public Adjectives MartyrAdjectives
    {
        get
        {
            return new Adjectives
            {
                HeroAdjective = "Successful",
                EnemyAdjective = "Doubtful"
            };
        }
    }

    public string GetCharacterStageContribution(long seed, string characterStage, IGenre genre, IDramaticQuestion dramaticQuestion)
    {
        return characterStage switch
        {
            "orphan" => "At this stage in the story, a vague outside force brings misery and misfortune upon the main character, and they struggle to identify it.",
            "wanderer" => "At this stage in the story, the unseen force continues to sneak up on the main character, who is distracted by shallower problems.",
            "warrior" => "At this stage in the story, the main character is fully at the mercy of the malevolent outside force.",
            "martyr" => "At this stage in the story, the main character is victorious by accepting their own humanity, surrendering and being at peace with the invisible forces of life they can't control.",
            _ => throw new ArgumentException(message: "invalid completion type value", paramName: nameof(characterStage)),
        };
    }

}