using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;
using StoryGhost.Enums;
using StoryGhost.Util;

namespace StoryGhost.Models.Archetypes;

public class Explorer : IArchetype
{
    public string Id { get { return "explorer"; } }
    public string Name { get { return "Explorer"; } }
    public string Description { get { return "The Explorer braves loneliness and hardship to discover the unknown. They shun the help of others, and view beaten paths with disdain. They want to improve their lives by searching for uniqueness and new perspectives, oblivious that what they seek is already within. They are ambitious, and always on the move toward the next goal."; } }
    public string SourceOfMotivation { get { return SourceOfMotivationEnum.OthersAndWorld; } }
    public string OrphanDesires { get { return "Self-discovery and fulfillment through authentic off-the-beaten-path experiences."; } }
    public string WandererResponse { get { return "Flee from the problem."; } }
    public string WarriorResponse { get { return "Journey with purpose, discover and experience novelty, escape boredom, be true to deeper self."; } }
    public List<string> GreatestFears
    {
        get
        {
            return new List<string>{
                "getting trapped", "conformity", "inner emptiness"
            };
        }
    }
    public List<string> Talents
    {
        get
        {
            return new List<string> {
                "autonomy", "ambition", "being true to one's soul", "identity", "expanded possibilities"
            };
        }
    }
    public List<string> Weaknesses
    {
        get
        {
            return new List<string> {
                "aimless wandering", "being a misfit", "rejecting help", "inability to commit", "chronic disappointment", "alienation", "loneliness"
            };
        }
    }
    public string AddictiveQuality { get { return "self-centeredness"; } }
    public List<string> Addictions
    {
        get
        {
            return new List<string>{
                "independence", "perfection of experience"
            };
        }
    }
    public string ShadowSide { get { return "They are chronically disappointed that their experiences don't live up to their expectations. They fail to accomplish big goals while jumping from one half-hearted attempt at self-improvement to the next."; } }
    public List<string> Examples
    {
        get
        {
            return new List<string>{
                "seeker", "iconoclast", "wanderer", "individualist", "pilgrim"
            };
        }
    }
    public string Motto { get { return "Don't fence me in."; } }



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
            "orphan" => $"The main character's only motivation is self-discovery and fulfillment through authentic off-the-beaten-path experiences, while they interact with the theme of {dramaticQuestion.Name.ToLower()} by demonstrating {dramaticQuestion.Contrary.ToLower()}.",
            "wanderer" => $"The main character attempts to flee from the problem, while they interact with the theme of {dramaticQuestion.Name.ToLower()} by demonstrating {dramaticQuestion.Contradiction.ToLower()}.",
            "warrior" => $"Despite the main character's attempts to flee from the problem, the problem persists. They interact with the theme of {dramaticQuestion.Name.ToLower()} by demonstrating {dramaticQuestion.Negation.ToLower()}.",
            "martyr" => $"Finally, the main character demonstrates {dramaticQuestion.Positive.ToLower()} and successfully handles the problem by journeying with purpose, discovering and experiencing novelty, and being true to their deeper self.",
            _ => throw new ArgumentException(message: "invalid completion type value", paramName: nameof(characterStage)),
        };
    }
}