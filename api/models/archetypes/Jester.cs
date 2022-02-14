using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;
using StoryGhost.Enums;

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
    public string ShadowSide { get { return "The Jester lacks dignity and self-control, engaging in gluttony, sloth, and lusts."; } }
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



    public AdviceSequence HeroAdviceSequence {
        get {
            return new AdviceSequence{
                
            };
        }
    }

    public AdviceSequence EnemyAdviceSequence {
        get {
            return new AdviceSequence{
                
            };
        }
    }


    public string GetHeroLogLineContribution(long seed, IGenre genre, IProblemTemplate problemTemplate, IArchetype enemyArchetype, IPrimalStakes primalStakes, IDramaticQuestion dramaticQuestion)
    {
        return $"The main character's personality is that of a {Name.ToLower()} (for example: {string.Join(", ", Examples)}).";
    }
    public string GetEnemyLogLineContribution(long seed, IGenre genre, IProblemTemplate problemTemplate, IArchetype heroArchetype, IPrimalStakes primalStakes, IDramaticQuestion dramaticQuestion)
    {
        return $"The personality of the secondary character (or antagonist) is that of a {Name.ToLower()} (for example: {string.Join(", ", Examples)}).";
    }

    public string GetCharacterStageContribution(long seed, string characterStage, IGenre genre, IProblemTemplate problemTemplate, IArchetype enemyArchetype, IPrimalStakes primalStakes, IDramaticQuestion dramaticQuestion)
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