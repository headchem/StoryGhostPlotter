using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;
using StoryGhost.Enums;
using StoryGhost.Util;

namespace StoryGhost.Models.Archetypes;

public class Creator : IArchetype
{
    public string Id { get { return "creator"; } }
    public string Name { get { return "Creator"; } }
    public string Description { get { return "The Creator is an imaginative visionary with the skill to bring their ideas to life. Adverse to stasis, they are prone to overcommit themselves. They fear the inability to implement their ideas in reality. They struggle to accept themselves and discover their inner artistic identity in relation to the external world."; } }
    public string SourceOfMotivation { get { return SourceOfMotivationEnum.OthersAndWorld; } }
    public string OrphanDesires { get { return "Enact their vision, proclaim their identity, create things of enduring value."; } }
    public string WandererResponse { get { return "Claim problem as a personal failing."; } }
    public string WarriorResponse { get { return "Develop artistic control and skill, create without needing validation, self-acceptance."; } }
    public List<string> GreatestFears
    {
        get
        {
            return new List<string>{
                "mediocre vision or execution", "inauthenticity"
            };
        }
    }
    public List<string> Talents
    {
        get
        {
            return new List<string> {
                "creativity", "vision", "individuality", "aesthetics", "skill", "vocation"
            };
        }
    }
    public List<string> Weaknesses
    {
        get
        {
            return new List<string> {
                "perfectionism", "bad solutions", "self-indulgence", "financial poverty", "creating messes", "prima-donna behaviors"
            };
        }
    }
    public string AddictiveQuality { get { return "obsessiveness"; } }
    public List<string> Addictions
    {
        get
        {
            return new List<string>{
                "work", "novelty"
            };
        }
    }
    public string ShadowSide { get { return "They are an obsessive workaholic, jumping from one half-baked idea to the next, as a distraction from their inner emptiness."; } }
    public List<string> Examples
    {
        get
        {
            return new List<string>{
                "artist", "inventor", "innovator", "musician", "writer"
            };
        }
    }
    public string Motto { get { return "If you can imagine it, it can be done."; } }


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

    public string GetCharacterStageContribution(long seed, string characterStage, IGenre genre, IProblemTemplate problemTemplate, IDramaticQuestion dramaticQuestion)
    {
        return characterStage switch
        {
            "orphan" => $"The main character's only motivation is to enact their vision, proclaim their identity, create things of enduring value. They interact with the theme of {dramaticQuestion.Name.ToLower()} by demonstrating {dramaticQuestion.Contrary.ToLower()}.",
            "wanderer" => $"The main character attempts to claim problem as a personal failing. They interact with the theme of {dramaticQuestion.Name.ToLower()} by demonstrating {dramaticQuestion.Contradiction.ToLower()}.",
            "warrior" => $"Despite all the main character's sucesses at bringing their ideas to life, the problem still persists. They interact with the theme of {dramaticQuestion.Name.ToLower()} by demonstrating {dramaticQuestion.Negation.ToLower()}.",
            "martyr" => $"Finally, the main character demonstrates {dramaticQuestion.Positive.ToLower()} and overcomes the problem through self-acceptance and skillfully creating without the need for external validation.",
            _ => throw new ArgumentException(message: "invalid completion type value", paramName: nameof(characterStage)),
        };
    }
}