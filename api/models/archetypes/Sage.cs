using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;
using StoryGhost.Enums;

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
    public string ShadowSide { get { return "The Sage can become a cold, pompous, dogmatic judge. They relish the feeling of superiority of being more correct than others."; } }
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




    public string GetHeroLogLineContribution(int seed, IGenre genre, IProblemTemplate problemTemplate, IArchetype enemyArchetype, IPrimalStakes primalStakes, IDramaticQuestion dramaticQuestion)
    {
        return $"HERO has a {Name} personality (for example: {string.Join(", ", Examples)}).";
    }
    public string GetEnemyLogLineContribution(int seed, IGenre genre, IProblemTemplate problemTemplate, IArchetype heroArchetype, IPrimalStakes primalStakes, IDramaticQuestion dramaticQuestion)
    {
        return $"ENEMY has a {Name} personality (for example: {string.Join(", ", Examples)}).";
    }
}