using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;
using StoryGhost.Enums;

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




    public string GetHeroLogLineContribution(int seed, IGenre genre, IProblemTemplate problemTemplate, IArchetype enemyArchetype, IPrimalStakes primalStakes, IDramaticQuestion dramaticQuestion)
    {
        return $"HERO has a {Name} personality (for example: {string.Join(", ", Examples)}).";
    }
    public string GetEnemyLogLineContribution(int seed, IGenre genre, IProblemTemplate problemTemplate, IArchetype heroArchetype, IPrimalStakes primalStakes, IDramaticQuestion dramaticQuestion)
    {
        return $"ENEMY has a {Name} personality (for example: {string.Join(", ", Examples)}).";
    }
}