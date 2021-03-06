using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;
using StoryGhost.Enums;
using StoryGhost.Util;

namespace StoryGhost.Models.Archetypes;

public class Magician : IArchetype
{
    public string Id { get { return "magician"; } }
    public string Name { get { return "Magician"; } }
    public string Description { get { return "The Magician wishes to achieve a higher plane of existence by using the laws of the universe to transform situations, influence others, and turn their vision into reality. Wielding great power, they fear causing unintentional harm. Prone to using their power manulatively, they can myopically mistake having power as the end goal."; } }
    public string SourceOfMotivation { get { return SourceOfMotivationEnum.Balanced; } }
    public string OrphanDesires { get { return "Materialize dreams, transform, understand the fundamental laws of the universe."; } }
    public string WandererResponse { get { return "Transform the problem."; } }
    public string WarriorResponse { get { return "Develop a vision and live by it, align self with cosmos, wield power as a tool."; } }
    public List<string> GreatestFears
    {
        get
        {
            return new List<string>{
                "unintended negative consequences", "evil sorcery"
            };
        }
    }
    public List<string> Talents
    {
        get
        {
            return new List<string> {
                "finding win-win solutions", "personal power", "transformation", "catalytic", "healing power"
            };
        }
    }
    public List<string> Weaknesses
    {
        get
        {
            return new List<string> {
                "manipulation of others", "disconnection with reality", "cultist and guru-like"
            };
        }
    }
    public string AddictiveQuality { get { return "dishonesty via illusion"; } }
    public List<string> Addictions
    {
        get
        {
            return new List<string>{
                "power", "mind-altering substances"
            };
        }
    }
    public string ShadowSide { get { return "They can become an evil sorcerer, transforming situations for the worse, or poisoning the thoughts of themself or others."; } }
    public List<string> Examples
    {
        get
        {
            return new List<string>{
                "visionary", "catalyst", "inventor", "charismatic leader", "shaman", "healer"
            };
        }
    }
    public string Motto { get { return "I make things happen."; } }


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
                ClosemindedToImaginativeTendency = 0.0,
                DisciplinedToSpontaneousTendency = 0.0,
                IntrovertToExtrovertTendency = -0.5,
                ColdToEmpatheticTendency = -0.33,
                UnflappableToAnxiousTendency = 0.0
            };
        }
    }

    public string GetCharacterStageContribution(long seed, string characterStage, IGenre genre, IProblemTemplate problemTemplate, IDramaticQuestion dramaticQuestion)
    {
        return characterStage switch
        {
            "orphan" => $"The main character's only motivation is to materialize dreams, transform, and understand the fundamental laws of the universe, while they interact with the theme of {dramaticQuestion.Name.ToLower()} by demonstrating {dramaticQuestion.Contrary.ToLower()}.",
            "wanderer" => $"The main character attempts to transform the problem, while they interact with the theme of {dramaticQuestion.Name.ToLower()} by demonstrating {dramaticQuestion.Contradiction.ToLower()}.",
            "warrior" => $"Despite the main character's attempts to transform the problem, the problem persists. They interact with the theme of {dramaticQuestion.Name.ToLower()} by demonstrating {dramaticQuestion.Negation.ToLower()}.",
            "martyr" => $"Finally, the main character demonstrates {dramaticQuestion.Positive.ToLower()} and successfully handles the problem by developing a vision and living by it, aligning self with cosmos, and wielding power as a tool.",
            _ => throw new ArgumentException(message: "invalid completion type value", paramName: nameof(characterStage)),
        };
    }
}