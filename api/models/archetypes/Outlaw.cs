using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;
using StoryGhost.Enums;
using StoryGhost.Util;

namespace StoryGhost.Models.Archetypes;

public class Outlaw : IArchetype
{
    public string Id { get { return "outlaw"; } }
    public string Name { get { return "Outlaw"; } }
    public string Description { get { return "The Outlaw is a ruthless fighter who deals with their repressed rage toward flawed social structures by destroying them, making way for new growth. They are careless with their own safety, unconsciously endangering others."; } }
    public string SourceOfMotivation { get { return SourceOfMotivationEnum.OthersAndWorld; } }
    public string OrphanDesires { get { return "Overturn what isn't working, metamorphosis, revenge, revolution."; } }
    public string WandererResponse { get { return "Allow problem to defeat them."; } }
    public string WarriorResponse { get { return "Disrupt, shock, destroy without fear or anger."; } }
    public List<string> GreatestFears
    {
        get
        {
            return new List<string>{
                "to be powerless or ineffectual", "annihilation"
            };
        }
    }
    public List<string> Talents
    {
        get
        {
            return new List<string> {
                "outrageousness", "radical freedom", "humility", "metamorphosis", "revolution", "capacity to let go"
            };
        }
    }
    public List<string> Weaknesses
    {
        get
        {
            return new List<string> {
                "crossing over to the dark side", "crime", "harm to self/others", "out of control anger", "terrorist tactics"
            };
        }
    }
    public string AddictiveQuality { get { return "self-destructiveness"; } }
    public List<string> Addictions
    {
        get
        {
            return new List<string>{
                "suicide", "self-destructive habits"
            };
        }
    }
    public string ShadowSide { get { return "They are self-destructive, giving in to addictions, compulsions, and behaviors that undermine intimacy. They are prone to emotional and physical abuse, and even murder."; } }
    public List<string> Examples
    {
        get
        {
            return new List<string>{
                "rebel", "revolutionary", "misfit", "iconoclast"
            };
        }
    }
    public string Motto { get { return "Rules are made to be broken."; } }


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
                IntrovertToExtrovertTendency = 0.0,
                ColdToEmpatheticTendency = -0.33,
                UnflappableToAnxiousTendency = 0.0
            };
        }
    }

    public string GetCharacterStageContribution(long seed, string characterStage, IGenre genre, IProblemTemplate problemTemplate, IDramaticQuestion dramaticQuestion)
    {
        return characterStage switch
        {
            "orphan" => $"The main character's only motivation is to overturn what isn't working and start a revolution, while they interact with the theme of {dramaticQuestion.Name.ToLower()} by demonstrating {dramaticQuestion.Contrary.ToLower()}.",
            "wanderer" => $"The main character allows the problem to defeat them, while they interact with the theme of {dramaticQuestion.Name.ToLower()} by demonstrating {dramaticQuestion.Contradiction.ToLower()}.",
            "warrior" => $"While allowing the problem to defeat them, the problem continues to get worse. They interact with the theme of {dramaticQuestion.Name.ToLower()} by demonstrating {dramaticQuestion.Negation.ToLower()}.",
            "martyr" => $"Finally, the main character demonstrates {dramaticQuestion.Positive.ToLower()} and successfully handles the problem by disrupting, shocking, and destroying without fear or anger.",
            _ => throw new ArgumentException(message: "invalid completion type value", paramName: nameof(characterStage)),
        };
    }
}