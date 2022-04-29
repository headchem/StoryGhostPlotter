using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;
using StoryGhost.Enums;
using StoryGhost.Util;

namespace StoryGhost.Models.Archetypes;

public class Jester : IArchetype
{
    public string Id { get { return "jester"; } }
    public string Name { get { return "Jester"; } }
    public string Description { get { return "The Jester has fun with life, despite its paradoxes and dilemmas. Prone to cruel jokes and debauchery, they fear boredom and nonaliveness."; } }
    public string SourceOfMotivation { get { return SourceOfMotivationEnum.Balanced; } }
    public string OrphanDesires { get { return "Have fun in the moment and lighten up the world."; } }
    public string WandererResponse { get { return "Play tricks and toy with the problem."; } }
    public string WarriorResponse { get { return "Be joyous while trusting in the process."; } }
    public List<string> GreatestFears
    {
        get
        {
            return new List<string>{
                "being bored or boring others", "nonaliveness"
            };
        }
    }
    public List<string> Talents
    {
        get
        {
            return new List<string> {
                "freedom", "humor", "living in the moment", "exuberant joy"
            };
        }
    }
    public List<string> Weaknesses
    {
        get
        {
            return new List<string> {
                "frivolity", "wasting time", "debauchery", "irresponsibility", "sloth", "cruel jokes", "conartistry"
            };
        }
    }
    public string AddictiveQuality { get { return "inebriation"; } }
    public List<string> Addictions
    {
        get
        {
            return new List<string>{
                "excitement", "stimulant drugs"
            };
        }
    }
    public string ShadowSide { get { return "They lacks dignity and self-control, engaging in gluttony, sloth, and lusts."; } }
    public List<string> Examples
    {
        get
        {
            return new List<string>{
                "fool", "trickster", "practical joker", "comedian"
            };
        }
    }
    public string Motto { get { return "You only live once."; } }



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
                ClosemindedToImaginativeTendency = 0.5,
                DisciplinedToSpontaneousTendency = 0.66,
                IntrovertToExtrovertTendency = 0.33,
                ColdToEmpatheticTendency = 0.0,
                UnflappableToAnxiousTendency = 0.0
            };
        }
    }

    public string GetCharacterStageContribution(long seed, string characterStage, IGenre genre, IProblemTemplate problemTemplate, IDramaticQuestion dramaticQuestion)
    {
        return characterStage switch
        {
            "orphan" => $"The main character's only motivation is to have fun in the moment and lighten up the world, while they interact with the theme of {dramaticQuestion.Name.ToLower()} by demonstrating {dramaticQuestion.Contrary.ToLower()}.",
            "wanderer" => $"The main character attempts to play tricks and toy with the problem, while they interact with the theme of {dramaticQuestion.Name.ToLower()} by demonstrating {dramaticQuestion.Contradiction.ToLower()}.",
            "warrior" => $"Despite the main character's attempts to play tricks and toy with the problem, the problem persists. They interact with the theme of {dramaticQuestion.Name.ToLower()} by demonstrating {dramaticQuestion.Negation.ToLower()}.",
            "martyr" => $"Finally, the main character demonstrates {dramaticQuestion.Positive.ToLower()} and successfully handles the problem by being joyous while trusting in the process.",
            _ => throw new ArgumentException(message: "invalid completion type value", paramName: nameof(characterStage)),
        };
    }
}