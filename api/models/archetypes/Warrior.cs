using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;
using StoryGhost.Enums;
using StoryGhost.Util;

namespace StoryGhost.Models.Archetypes;

public class Warrior : IArchetype
{
    public string Id { get { return "warrior"; } }
    public string Name { get { return "Warrior"; } }
    public string Description { get { return "The Warrior is tough and courageous, focused on overcoming obstacles. They fear being vulnerable, which leads to every interaction being evaluated as a threat. They justify ruthless and immoral tactics for the sake of winning."; } }
    public string SourceOfMotivation { get { return SourceOfMotivationEnum.Themselves; } }
    public string OrphanDesires { get { return "Expert mastery in a way that improves the world, win, to prove one's worth through courageous acts."; } }
    public string WandererResponse { get { return "Dig in and recklessly confront the problem."; } }
    public string WarriorResponse { get { return "To be as strong and competent as possible, fight only for what really matters."; } }
    public List<string> GreatestFears
    {
        get
        {
            return new List<string>{
                "weakness", "vulnerability", "being a coward"
            };
        }
    }
    public List<string> Talents
    {
        get
        {
            return new List<string> {
                "competence", "courage", "discipline", "determination", "skill"
            };
        }
    }
    public List<string> Weaknesses
    {
        get
        {
            return new List<string> {
                "arrogance", "always looking for a fight", "fear of impotence leading to ruthlessness"
            };
        }
    }
    public string AddictiveQuality { get { return "stoicism"; } }
    public List<string> Addictions
    {
        get
        {
            return new List<string>{
                "achievement", "success"
            };
        }
    }
    public string ShadowSide { get { return "The Warrior becomes the villain when they use their battle skills for personal gain, disregarding the good of the group. They are willing to compromise their principles to win. Constantly feeling embattled, they are on on edge and ready to fight at even the smallest percieved slight."; } }
    public List<string> Examples
    {
        get
        {
            return new List<string>{
                "crusader", "rescuer", "superhero", "soldier"
            };
        }
    }
    public string Motto { get { return "Where there's a will, there's a way."; } }



    public SequenceAdvices HeroAdviceSequence
    {
        get
        {
            return new SequenceAdvices
            {
                Events = new AdviceSequence
                {
                    Setup = $"Show the main character's talents of {Factory.GetKeywordsSentence("", Talents)}",
                    FunAndGames = $"The main character struggles with their weaknesses of: {Factory.GetKeywordsSentence("", Weaknesses)}",
                    BadGuysCloseIn = $"The main character struggles with their addictive quality of {AddictiveQuality.ToLower()} and addictions of: {Factory.GetKeywordsSentence("", Addictions)}. They show their shadow side of: {ShadowSide}",
                    AllHopeIsLost = $"The main character's worst fears come true: {Factory.GetKeywordsSentence("", GreatestFears)}",
                },
                Context = new AdviceSequence
                {
                    Setup = $"The main character wants to {OrphanDesires.ToLower()}",
                    Debate = $"The main character wants to {WandererResponse.ToLower()}",
                    DarkNightOfTheSoul = $"The main character wants to {WarriorResponse.ToLower()}"
                }
            };
        }
    }

    public string GetCharacterStageContribution(long seed, string characterStage, IGenre genre, IProblemTemplate problemTemplate, IDramaticQuestion dramaticQuestion)
    {
        return characterStage switch
        {
            "orphan" => $"The main character's only motivation is to work toward improving the world, win, to prove their worth through courageous acts, while they interact with the theme of {dramaticQuestion.Name.ToLower()} by demonstrating {dramaticQuestion.Contrary.ToLower()}.",
            "wanderer" => $"The main character attempts to dig in and recklessly confront the problem, while they interact with the theme of {dramaticQuestion.Name.ToLower()} by demonstrating {dramaticQuestion.Contradiction.ToLower()}.",
            "warrior" => $"Despite the main character's attempts to dig in and recklessly confront the problem, the problem persists. They interact with the theme of {dramaticQuestion.Name.ToLower()} by demonstrating {dramaticQuestion.Negation.ToLower()}.",
            "martyr" => $"Finally, the main character demonstrates {dramaticQuestion.Positive.ToLower()} and successfully handles the problem by being as strong and competent as possible, and to fight only for what really matters.",
            _ => throw new ArgumentException(message: "invalid completion type value", paramName: nameof(characterStage)),
        };
    }
}