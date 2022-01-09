using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;
using StoryGhost.Enums;

namespace StoryGhost.Models.Archetypes;

public class Creator : IArchetype
{
    public string Id { get { return "creator"; } }
    public string Name { get { return "Creator"; } }
    public string Description { get { return "The Creator is an imaginative visionary with the skill to bring their ideas to life. Adverse to stasis, they are prone to overcommit themselves. They fear the inability to implement their ideas in reality. They struggle to accept themselves and discover their inner artistic identity in relation to the external world."; } }
    public string SourceOfMotivation { get { return SourceOfMotivationEnum.OthersAndWorld; } }
    public string OrphanDesires { get { return "Enact their vision, proclaim their identity, create things of enduring value."; } }
    public string WandererResponse { get { return "Claim problem as a personal failing."; } }
    public string WarriorResponse { get { return "Develop artistic control and skill, create without needing validation, self-acceptance."; } }
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
                "work", "novelty"
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
            "orphan" => $"The main character's only motivation is to enact their vision, proclaim their identity, create things of enduring value. They interact with the theme of {dramaticQuestion.Name.ToLower()} by demonstrating {dramaticQuestion.Contrary.ToLower()}",
            "wanderer" => $"The main character attempts to claim problem as a personal failing. They interact with the theme of {dramaticQuestion.Name.ToLower()} by demonstrating {dramaticQuestion.Contradiction.ToLower()}.",
            "warrior" => $"Despite all the main character's sucesses at bringing their ideas to life, the problem still persists. They interact with the theme of {dramaticQuestion.Name.ToLower()} by demonstrating {dramaticQuestion.Negation.ToLower()}.",
            "martyr" => $"Finally, the main character demonstrates {dramaticQuestion.Positive.ToLower()} and overcomes the problem through self-acceptance and skillfully creating without the need for external validation.",
            _ => throw new ArgumentException(message: "invalid completion type value", paramName: nameof(characterStage)),
        };
    }
}