using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.PrimalStakes;

public class ExactRevenge : IPrimalStakes
{
    public string Id { get { return "exactRevenge"; } }
    public string Name { get { return "exact revenge"; } }
    public string Description { get { return "After the Hero is betrayed, they seek justice against the entities that harmed them."; } }
    public List<string> Keywords
    {
        get
        {
            return new List<string>{
                "betrayal", "seething", "catharsis", "justice"
            };
        }
    }

    public string GetCharacterStageContribution(int seed, string characterStage, IGenre genre, IProblemTemplate problemTemplate, IArchetype heroArchetype, IArchetype enemyArchetype, IDramaticQuestion dramaticQuestion)
    {
        return characterStage switch
        {
            "orphan" => "The main character starts off trusting, but one of the other characters betrays them.",
            "wanderer" => "The main character reels from the betrayal, and formulates a plan to get revenge.",
            "warrior" => "The main character's plan for revenage looks like it will fail.",
            "martyr" => "Using lessons the main character learned throughout this ordeal, they successsfully get their revenge.",
            _ => throw new ArgumentException(message: "invalid completion type value", paramName: nameof(characterStage)),
        };
    }

}