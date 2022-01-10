using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.PrimalStakes;

public class FindConnection : IPrimalStakes
{
    public string Id { get { return "findConnection"; } }
    public string Name { get { return "find connection"; } }
    public string Description { get { return "The Hero lacks a deep connection in life, and they are irresistably drawn to another entity that is seemingly incompatible. As the two learn more about each other, they develop a strong bond."; } }
    public List<string> Keywords
    {
        get
        {
            return new List<string>{
                "loneliness", "rescue", "connection", "passion", "belonging"
            };
        }
    }

    public string GetCharacterStageContribution(int seed, string characterStage, IGenre genre, IProblemTemplate problemTemplate, IArchetype heroArchetype, IArchetype enemyArchetype, IDramaticQuestion dramaticQuestion)
    {
        return characterStage switch
        {
            "orphan" => "The main character starts off without any deep emotional connections, but they meet another character which starts a connection.",
            "wanderer" => "The main character attempts to bond with another character, and it appears to be going well, despite their incompatibilities.",
            "warrior" => "The main character's relationships are crumbling and they alienate themselves.",
            "martyr" => "Using lessons the main character learned throughout this ordeal, they successsfully cement a deep emotional bond.",
            _ => throw new ArgumentException(message: "invalid completion type value", paramName: nameof(characterStage)),
        };
    }

}