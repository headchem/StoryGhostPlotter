using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.PrimalStakes;

public class ProtectPossession : IPrimalStakes
{
    public string Id { get { return "protectPossession"; } }
    public string Name { get { return "protect a possession"; } }
    public string Description { get { return "The Hero possesses or desires a special object that gives their life meaning. An outsider threatens to destroy or steal the object, while the Hero will sacrifice everything to protect or acquire the object."; } }
    public List<string> Keywords
    {
        get
        {
            return new List<string>{
                "greed", "prize", "abundance", "covet", "possess"
            };
        }
    }

    public string GetCharacterStageContribution(int seed, string characterStage, IGenre genre, IProblemTemplate problemTemplate, IArchetype heroArchetype, IArchetype enemyArchetype, IDramaticQuestion dramaticQuestion)
    {
        return characterStage switch
        {
            "orphan" => "The main character starts off with a valuable possession, but a dangerous outsider threatens them.",
            "wanderer" => "The main character is able to partially protect their possession, but the root problem is still a threat.",
            "warrior" => "The main character is incapacitated, and appears to have lost any ability to protect the possession.",
            "martyr" => "Using lessons the main character learned throughout this ordeal, they successfully protect the possession, defeating the threat once and for all.",
            _ => throw new ArgumentException(message: "invalid completion type value", paramName: nameof(characterStage)),
        };
    }

}