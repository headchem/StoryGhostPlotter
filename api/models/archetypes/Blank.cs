using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;
using StoryGhost.Enums;
using StoryGhost.Util;

namespace StoryGhost.Models.Archetypes;

public class Blank : IArchetype
{
    public string Id { get { return ""; } }
    public string Name { get { return ""; } }
    public string Description { get { return ""; } }
    public string SourceOfMotivation { get { return SourceOfMotivationEnum.Balanced; } }
    public string OrphanDesires { get { return ""; } }
    public string WandererResponse { get { return ""; } }
    public string WarriorResponse { get { return ""; } }
    public List<string> GreatestFears
    {
        get
        {
            return new List<string>
            {
            };
        }
    }
    public List<string> Talents
    {
        get
        {
            return new List<string>
            {
            };
        }
    }
    public List<string> Weaknesses
    {
        get
        {
            return new List<string>
            {
            };
        }
    }
    public string AddictiveQuality { get { return ""; } }
    public List<string> Addictions
    {
        get
        {
            return new List<string>
            {
            };
        }
    }
    public string ShadowSide { get { return ""; } }
    public List<string> Examples
    {
        get
        {
            return new List<string>
            {
            };
        }
    }
    public string Motto { get { return ""; } }


    public SequenceAdvices HeroAdviceSequence
    {
        get
        {
            return new SequenceAdvices
            {
                Events = new AdviceSequence
                {
                },
                Context = new AdviceSequence
                {
                }
            };
        }
    }

    public ArchetypePersonalityTendencies PersonalityTendencies
    {
        get
        {
            return new ArchetypePersonalityTendencies
            {
                ClosemindedToImaginativeTendency = 0.0,
                DisciplinedToSpontaneousTendency = 0.0,
                IntrovertToExtrovertTendency = 0.0,
                ColdToEmpatheticTendency = 0.0,
                UnflappableToAnxiousTendency = 0.0
            };
        }
    }

    public string GetCharacterStageContribution(long seed, string characterStage, IGenre genre, IProblemTemplate problemTemplate, IDramaticQuestion dramaticQuestion)
    {
        return characterStage switch
        {
            "orphan" => $"",
            "wanderer" => $"",
            "warrior" => $"",
            "martyr" => $"",
            _ => throw new ArgumentException(message: "invalid completion type value", paramName: nameof(characterStage)),
        };
    }

}