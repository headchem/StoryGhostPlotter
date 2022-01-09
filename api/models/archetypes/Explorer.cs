using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;
using StoryGhost.Enums;

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
    public string ShadowSide { get { return "The Explorer is chronically disappointed that their experiences don't live up to their expectations. They fail to accomplish big goals while jumping from one half-hearted attempt at self-improvement to the next."; } }
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




    public string GetHeroLogLineContribution(int seed, IGenre genre, IProblemTemplate problemTemplate, IArchetype enemyArchetype, IPrimalStakes primalStakes, IDramaticQuestion dramaticQuestion)
    {
        return $"The main character's personality is that of a {Name.ToLower()} (for example: {string.Join(", ", Examples)}).";
    }
    public string GetEnemyLogLineContribution(int seed, IGenre genre, IProblemTemplate problemTemplate, IArchetype heroArchetype, IPrimalStakes primalStakes, IDramaticQuestion dramaticQuestion)
    {
        return $"The antagonist's personality is that of a {Name.ToLower()} (for example: {string.Join(", ", Examples)}).";
    }

    public string GetCharacterStageContribution(int seed, string characterStage, IGenre genre, IProblemTemplate problemTemplate, IArchetype enemyArchetype, IPrimalStakes primalStakes, IDramaticQuestion dramaticQuestion)
    {
        return characterStage switch
        {
            "orphan" => "",
            "wanderer" => "",
            "warrior" => "",
            "martyr" => "",
            _ => throw new ArgumentException(message: "invalid completion type value", paramName: nameof(characterStage)),
        };
    }
}