using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;
using StoryGhost.Enums;
using StoryGhost.Util;

namespace StoryGhost.Models.Archetypes;

public class Sage : IArchetype
{
    public string Id { get { return "sage"; } }
    public string Name { get { return "Sage"; } }
    public string Description { get { return "The Sage will journey far in search of nugets of objective truth, hoping they aggregate into enlightenment. They fear ignorance and deception, making them prone to over analysis. Their great intellect can lead to pompous and overly critical attitudes towards others."; } }
    public string SourceOfMotivation { get { return SourceOfMotivationEnum.Balanced; } }
    public string OrphanDesires { get { return "To use intelligence and analysis to understand the world, to find the truth."; } }
    public string WandererResponse { get { return "Transcend the problem."; } }
    public string WarriorResponse { get { return "Seek knowledge, understand own thought process, attain enlightenment."; } }
    public List<string> GreatestFears
    {
        get
        {
            return new List<string>{
                "being duped or misled", "ignorance", "deception"
            };
        }
    }
    public List<string> Talents
    {
        get
        {
            return new List<string> {
                "wisdom", "intelligence", "nonattachment", "knowledge", "skepticism"
            };
        }
    }
    public List<string> Weaknesses
    {
        get
        {
            return new List<string> {
                "analysis paralysis", "being overly critical", "pomposity", "impracticality", "lacking feeling/empathy"
            };
        }
    }
    public string AddictiveQuality { get { return "judgmentalism"; } }
    public List<string> Addictions
    {
        get
        {
            return new List<string>{
                "being right", "tranquilizers"
            };
        }
    }
    public string ShadowSide { get { return "They can become a cold, pompous, dogmatic judge. They relish the feeling of superiority of being more correct than others."; } }
    public List<string> Examples
    {
        get
        {
            return new List<string>{
                "expert", "scholar", "detective", "advisor", "thinker", "philosopher", "planner", "mentor", "teacher"
            };
        }
    }
    public string Motto { get { return "The truth will set you free."; } }


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
            "orphan" => $"The main character's only motivation is to use intelligence and analysis to understand the world, while they interact with the theme of {dramaticQuestion.Name.ToLower()} by demonstrating {dramaticQuestion.Contrary.ToLower()}.",
            "wanderer" => $"The main character attempts to transcend the problem, while they interact with the theme of {dramaticQuestion.Name.ToLower()} by demonstrating {dramaticQuestion.Contradiction.ToLower()}.",
            "warrior" => $"Despite the main character's attempts to transcend the problem, the problem persists. They interact with the theme of {dramaticQuestion.Name.ToLower()} by demonstrating {dramaticQuestion.Negation.ToLower()}.",
            "martyr" => $"Finally, the main character demonstrates {dramaticQuestion.Positive.ToLower()} and successfully handles the problem by seeking knowledge, understanding their own thought process, and attaining enlightenment.",
            _ => throw new ArgumentException(message: "invalid completion type value", paramName: nameof(characterStage)),
        };
    }
}