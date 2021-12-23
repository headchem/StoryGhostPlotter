using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;
using StoryGhost.Enums;

namespace StoryGhost.Models.Archetypes;

public class Creator: IArchetype
{
    public string Id { get { return "creator"; } }
    public string Name { get { return "Creator"; } }
    public string Description { get { return "The Creator is an imaginative visionary with the skill to bring their ideas to life. Adverse to stasis, they are prone to overcommit themselves. They fear the inability to implement their ideas in reality. They struggle to accept themselves and discover their inner artistic identity in relation to the external world."; } }
    public string SourceOfMotivation { get { return SourceOfMotivationEnum.OthersAndWorld; } }
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
        "work", "creativity"
    };
        }
    }
    public string ShadowSide { get { return "The Creator is an obsessive workaholic, jumping from one half-baked idea to the next, as a distraction from their inner emptiness."; } }
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

    public string GetHeroLogLineContribution(IGenre genre, IProblemTemplate problemTemplate, IArchetype enemyArchetype, IPrimalStakes primalStakes, IDramaticQuestion dramaticQuestion)
    {
        return "Creator LogLine prompt contribution for Hero";
    }
    public string GetEnemyLogLineContribution(IGenre genre, IProblemTemplate problemTemplate, IArchetype heroArchetype, IPrimalStakes primalStakes, IDramaticQuestion dramaticQuestion)
    {
        return "Creator LogLine prompt contribution for Enemy";
    }
}