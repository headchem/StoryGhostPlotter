using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;
using StoryGhost.Enums;
using StoryGhost.Util;

namespace StoryGhost.Models.Archetypes;

public class Innocent : IArchetype
{
    public string Id { get { return "innocent"; } }
    public string Name { get { return "Innocent"; } }
    public string Description { get { return "The Innocent is optimistic and trusting that the future is bright, endearing them to others. They have a child-like spontaneity to start any journey. Prone to naiveté, they are blind to their own weaknesses, and become dependent on others to accomplish their goals. They fear abandonment and seek safety."; } }
    public string SourceOfMotivation { get { return SourceOfMotivationEnum.Themselves; } }
    public string OrphanDesires { get { return "Be happy, remain in safety, reach their personal metaphorical paradise."; } }
    public string WandererResponse { get { return "Deny the problem or seek rescue."; } }
    public string WarriorResponse { get { return "Do things right, loyally endangers self, discernment."; } }
    public List<string> GreatestFears
    {
        get
        {
            return new List<string>{
                "to be punished for doing something bad/wrong", "abandonment"
            };
        }
    }
    public List<string> Talents
    {
        get
        {
            return new List<string> {
                "optimism", "trust", "hope", "faith", "simplicity"
            };
        }
    }
    public List<string> Weaknesses
    {
        get
        {
            return new List<string> {
                "boring for all their innocence", "naiveté", "childish dependence", "denial", "obliviousness"
            };
        }
    }
    public string AddictiveQuality { get { return "denial"; } }
    public List<string> Addictions
    {
        get
        {
            return new List<string>{
                "consumerism", "sugar", "cheerfulness"
            };
        }
    }
    public string ShadowSide { get { return "Addicted to feeling good, the Innocent represses and denies the genuine hurt of self or others. They show excessive deference to others, even if they know better."; } }
    public List<string> Examples
    {
        get
        {
            return new List<string>{
                "uopian", "traditionalist", "naive", "mystic", "saint", "romantic", "dreamer"
            };
        }
    }
    public string Motto { get { return "Free to be you and me."; } }



    public SequenceAdvices HeroAdviceSequence
    {
        get
        {
            return new SequenceAdvices
            {
                Events = new AdviceSequence
                {
                    Setup = $"The main character wants to {OrphanDesires.ToLower()} Show their talents of {Factory.GetKeywordsSentence("", Talents)}",
                    Debate = $"The main character wants to {WandererResponse.ToLower()}",
                    FunAndGames = $"The main character struggles with their weaknesses of: {Factory.GetKeywordsSentence("", Weaknesses)}",
                    BadGuysCloseIn = $"The main character struggles with their addictive quality of {AddictiveQuality.ToLower()} and addictions of: {Factory.GetKeywordsSentence("", Addictions)}. They show their shadow side of: {ShadowSide}",
                    AllHopeIsLost = $"The main character's worst fears come true: {Factory.GetKeywordsSentence("", GreatestFears)}",
                    DarkNightOfTheSoul = $"The main character wants to {WarriorResponse.ToLower()}"
                },
                Context = new AdviceSequence
                {

                }
            };
        }
    }

    public string GetCharacterStageContribution(long seed, string characterStage, IGenre genre, IProblemTemplate problemTemplate, IDramaticQuestion dramaticQuestion)
    {
        return characterStage switch
        {
            "orphan" => $"The main character's only motivation is to be happy, remain in safety, and get to paradise, while they interact with the theme of {dramaticQuestion.Name.ToLower()} by demonstrating {dramaticQuestion.Contrary.ToLower()}.",
            "wanderer" => $"The main character attempts to deny the problem or seek rescue from it, while they interact with the theme of {dramaticQuestion.Name.ToLower()} by demonstrating {dramaticQuestion.Contradiction.ToLower()}.",
            "warrior" => $"Despite the main character's attempts to deny the problem or be rescued from it, the problem persists. They interact with the theme of {dramaticQuestion.Name.ToLower()} by demonstrating {dramaticQuestion.Negation.ToLower()}.",
            "martyr" => $"Finally, the main character demonstrates {dramaticQuestion.Positive.ToLower()} and successfully handles the problem by doing things the right way, loyally endangering themselves, and showing discernment.",
            _ => throw new ArgumentException(message: "invalid completion type value", paramName: nameof(characterStage)),
        };
    }
}