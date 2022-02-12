using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.PrimalStakes;

public class ProtectFamily : IPrimalStakes
{
    public string Id { get { return "protectFamily"; } }
    public string Name { get { return "protect one's family"; } }
    public string Description { get { return "The Hero's family is threatened by a dangerous outsider. Despite conflicts within the family, their bonds cannot be broken, and the Hero will stop at nothing to protect them."; } }
    public List<string> Keywords
    {
        get
        {
            return new List<string>{
                "safety", "threat", "bonds"
            };
        }
    }

    public string GetCharacterStageContribution(long seed, string characterStage, IGenre genre, IProblemTemplate problemTemplate, IArchetype heroArchetype, IArchetype enemyArchetype, IDramaticQuestion dramaticQuestion)
    {
        return characterStage switch
        {
            "orphan" => "The main character starts off with their family in safety, but a dangerous outsider threatens them.",
            "wanderer" => "The main character is able to partially protect their family, but the root problem is still a threat.",
            "warrior" => "The main character is incapacitated, and appears to have lost any ability to protect their family.",
            "martyr" => "Using lessons the main character learned throughout this ordeal, they successfully protect their family, defeating the threat once and for all.",
            _ => throw new ArgumentException(message: "invalid completion type value", paramName: nameof(characterStage)),
        };
    }

}