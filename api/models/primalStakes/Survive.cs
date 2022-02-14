using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.PrimalStakes;

public class Survive : IPrimalStakes
{
    public string Id { get { return "survive"; } }
    public string Name { get { return "survive"; } }
    public string Description { get { return "An Enemy threatens the safety of the Hero's identity or physical existence. The Hero's will to persevere is tested, but they ultimately find peace."; } }
    public List<string> Keywords
    {
        get
        {
            return new List<string>{
                "safety", "danger", "resistance"
            };
        }
    }

    public AdviceSequence AdviceSequence
    {
        get
        {
            return new AdviceSequence
            {
            };
        }
    }

    public string GetCharacterStageContribution(long seed, string characterStage, IGenre genre, IProblemTemplate problemTemplate, IArchetype heroArchetype, IArchetype enemyArchetype, IDramaticQuestion dramaticQuestion)
    {
        return characterStage switch
        {
            "orphan" => "The main character starts off comfortable in their life, but an event threatens their survival.",
            "wanderer" => "The main character is able to partially survive, but the root problem is still a threat.",
            "warrior" => "The main character's will to persevere is tested, and they appear to be losing the battle to survive.",
            "martyr" => "Using lessons the main character learned throughout this ordeal, they successfully survive the ordeal and find peace.",
            _ => throw new ArgumentException(message: "invalid completion type value", paramName: nameof(characterStage)),
        };
    }

}