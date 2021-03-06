using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;
using StoryGhost.Enums;
using StoryGhost.Util;

namespace StoryGhost.Models.Archetypes;

public class Orphan : IArchetype
{
    public string Id { get { return "orphan"; } }
    public string Name { get { return "Orphan"; } }
    public string Description { get { return "The Orphan has metaphorically skipped childhood. They are unpretentious, street smart, and empathize with the struggle of others. They fear exploitation and being singled out from the crowd. They are prone to a victim mentality and must parent themselves."; } }
    public string SourceOfMotivation { get { return SourceOfMotivationEnum.Themselves; } }
    public string OrphanDesires { get { return "To belong, regain safety, connect with others."; } }
    public string WandererResponse { get { return "Be victimized by the problem."; } }
    public string WarriorResponse { get { return "Develop ordinary solid virtues, be down to earth, process and feel pain fully."; } }
    public List<string> GreatestFears
    {
        get
        {
            return new List<string>{
                "to be left out or to stand out from the crowd", "exploitation"
            };
        }
    }
    public List<string> Talents
    {
        get
        {
            return new List<string> {
                "realism", "empathy", "lack of pretense", "interdependence", "resilience"
            };
        }
    }
    public List<string> Weaknesses
    {
        get
        {
            return new List<string> {
                "suppressing true self to blend in or maintain superficial relationships", "cynicism", "tendency to be the victim", "chronic complaining"
            };
        }
    }
    public string AddictiveQuality { get { return "cynicism"; } }
    public List<string> Addictions
    {
        get
        {
            return new List<string>{
                "powerlessness", "worrying"
            };
        }
    }
    public string ShadowSide { get { return "They see themselves as a victim, and blame their predatory behavior and incompetence on others. They expect special treatment due to being fragile from past victimization. They attack people who are trying to help them, or collapse and become dysfunctional."; } }
    public List<string> Examples
    {
        get
        {
            return new List<string>{
                "down-to-earth", "realist", "diligent worker", "solid citizen", "good neighbor"
            };
        }
    }
    public string Motto { get { return "All people are created equal."; } }


    public SequenceAdvices HeroAdviceSequence
    {
        get
        {
            return new SequenceAdvices
            {
                Events = new AdviceSequence
                {
                    Setup = $"Show the main character's talents of {Factory.GetKeywordsSentence("", Talents)}.",
                    FunAndGames = $"The main character struggles with their weaknesses of: {Factory.GetKeywordsSentence("", Weaknesses)}.",
                    BadGuysCloseIn = $"The main character struggles with their addictive quality of {AddictiveQuality.ToLower()} and addictions of: {Factory.GetKeywordsSentence("", Addictions)}. They show their shadow side of: {ShadowSide.TrimEnd('.')}.",
                    AllHopeIsLost = $"The main character's worst fears come true: {Factory.GetKeywordsSentence("", GreatestFears)}.",
                },
                Context = new AdviceSequence
                {
                    Setup = $"The main character wants to {OrphanDesires.ToLower().TrimEnd('.')}.",
                    Debate = $"The main character wants to {WandererResponse.ToLower().TrimEnd('.')}.",
                    DarkNightOfTheSoul = $"The main character wants to {WarriorResponse.ToLower().TrimEnd('.')}."
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
                ClosemindedToImaginativeTendency = -0.33,
                DisciplinedToSpontaneousTendency = -0.5,
                IntrovertToExtrovertTendency = 0.0,
                ColdToEmpatheticTendency = 0.0,
                UnflappableToAnxiousTendency = -0.5
            };
        }
    }

    public string GetCharacterStageContribution(long seed, string characterStage, IGenre genre, IProblemTemplate problemTemplate, IDramaticQuestion dramaticQuestion)
    {
        return characterStage switch
        {
            "orphan" => $"The main character's only motivation is to belong, be in safety, and connect with others, while they interact with the theme of {dramaticQuestion.Name.ToLower()} by demonstrating {dramaticQuestion.Contrary.ToLower()}.",
            "wanderer" => $"The main character allows themselves to be victimized by the problem, while they interact with the theme of {dramaticQuestion.Name.ToLower()} by demonstrating {dramaticQuestion.Contradiction.ToLower()}.",
            "warrior" => $"While the main character is victimized by the problem, the problem continues to get worse. They interact with the theme of {dramaticQuestion.Name.ToLower()} by demonstrating {dramaticQuestion.Negation.ToLower()}.",
            "martyr" => $"Finally, the main character demonstrates {dramaticQuestion.Positive.ToLower()} and successfully handles the problem by developing ordinary solid virtues, being down to earth, and processing pain fully.",
            _ => throw new ArgumentException(message: "invalid completion type value", paramName: nameof(characterStage)),
        };
    }
}