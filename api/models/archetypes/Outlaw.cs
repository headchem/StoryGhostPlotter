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
    public string ShadowSide { get { return "The Outlaw is self-destructive, giving in to addictions, compulsions, and behaviors that undermine intimacy. They are prone to emotional and physical abuse, and even murder."; } }
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


    public AdviceSequence HeroAdviceSequence
    {
        get
        {
            return new AdviceSequence
            {
                Setup = $"The main character wants to {OrphanDesires.ToLower()} Show their talents of {Factory.GetKeywordsSentence("", Talents)}",
                Debate = $"The main character wants to {WandererResponse.ToLower()}",
                FunAndGames = $"The main character struggles with their weaknesses of: {Factory.GetKeywordsSentence("", Weaknesses)}",
                BadGuysCloseIn = $"The main character struggles with their addictive quality of {AddictiveQuality.ToLower()} and addictions of: {Factory.GetKeywordsSentence("", Addictions)}. They show their shadow side of: {ShadowSide}",
                AllHopeIsLost = $"The main character's worst fears come true: {Factory.GetKeywordsSentence("", GreatestFears)}",
                DarkNightOfTheSoul = $"The main character wants to {WarriorResponse.ToLower()}."
            };
        }
    }

    public AdviceSequence EnemyAdviceSequence
    {
        get
        {
            return new AdviceSequence
            {

            };
        }
    }


    public string GetHeroLogLineContribution(long seed, IGenre genre, IProblemTemplate problemTemplate, IArchetype enemyArchetype, IPrimalStakes primalStakes, IDramaticQuestion dramaticQuestion)
    {
        return $"The main character's personality is that of an {Name.ToLower()} (for example: {string.Join(", ", Examples)}).";
    }
    public string GetEnemyLogLineContribution(long seed, IGenre genre, IProblemTemplate problemTemplate, IArchetype heroArchetype, IPrimalStakes primalStakes, IDramaticQuestion dramaticQuestion)
    {
        return $"The personality of the secondary character (or antagonist) is that of an {Name.ToLower()} (for example: {string.Join(", ", Examples)}).";
    }

    public string GetCharacterStageContribution(long seed, string characterStage, IGenre genre, IProblemTemplate problemTemplate, IArchetype enemyArchetype, IPrimalStakes primalStakes, IDramaticQuestion dramaticQuestion)
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