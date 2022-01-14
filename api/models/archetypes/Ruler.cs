using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;
using StoryGhost.Enums;

namespace StoryGhost.Models.Archetypes;

public class Ruler : IArchetype
{
    public string Id { get { return "ruler"; } }
    public string Name { get { return "Ruler"; } }
    public string Description { get { return "The Ruler feels a responsibility to create order and structure so their subjects can be productive, synergistic, and happy. They fear chaos and being usurped, which makes them prone to domination and demanding ultimate authority."; } }
    public string SourceOfMotivation { get { return SourceOfMotivationEnum.Balanced; } }
    public string OrphanDesires { get { return "Create a prosperous, successful family or community, order, control."; } }
    public string WandererResponse { get { return "Find constructive uses of the problem."; } }
    public string WarriorResponse { get { return "Exercise power, take full responsibility for your life."; } }
    public List<string> GreatestFears
    {
        get
        {
            return new List<string>{
                "chaos", "being overthrown"
            };
        }
    }
    public List<string> Talents
    {
        get
        {
            return new List<string> {
                "responsibility", "leadership", "control", "sovereignty", "system savvy"
            };
        }
    }
    public List<string> Weaknesses
    {
        get
        {
            return new List<string> {
                "being authoritarian", "unable to delegate", "rigidity", "controlling behaviors", "attitude of entitlement", "elitism"
            };
        }
    }
    public string AddictiveQuality { get { return "high control needs"; } }
    public List<string> Addictions
    {
        get
        {
            return new List<string>{
                "control", "codependence"
            };
        }
    }
    public string ShadowSide { get { return "The Ruler can become an ogre tyrant, demanding loyalty instead of earning it. They banish all perspectives that are not their own to maintain control at any price."; } }
    public List<string> Examples
    {
        get
        {
            return new List<string>{
                "boss", "leader", "aristocrat", "royalty", "politician", "role model", "manager", "administrator"
            };
        }
    }
    public string Motto { get { return "Power isn't everything, it's the only thing."; } }




    public string GetHeroLogLineContribution(int seed, IGenre genre, IProblemTemplate problemTemplate, IArchetype enemyArchetype, IPrimalStakes primalStakes, IDramaticQuestion dramaticQuestion)
    {
        return $"The main character's personality is that of a {Name.ToLower()} (for example: {string.Join(", ", Examples)}).";
    }
    public string GetEnemyLogLineContribution(int seed, IGenre genre, IProblemTemplate problemTemplate, IArchetype heroArchetype, IPrimalStakes primalStakes, IDramaticQuestion dramaticQuestion)
    {
        return $"The personality of the secondary character (or antagonist) is that of a {Name.ToLower()} (for example: {string.Join(", ", Examples)}).";
    }

    public string GetCharacterStageContribution(int seed, string characterStage, IGenre genre, IProblemTemplate problemTemplate, IArchetype enemyArchetype, IPrimalStakes primalStakes, IDramaticQuestion dramaticQuestion)
    {
        return characterStage switch
        {
            "orphan" => $"The main character's only motivation is to create an ordered and prosperous family or community, while they interact with the theme of {dramaticQuestion.Name.ToLower()} by demonstrating {dramaticQuestion.Contrary.ToLower()}.",
            "wanderer" => $"The main character attempts to find constructive uses of the problem, while they interact with the theme of {dramaticQuestion.Name.ToLower()} by demonstrating {dramaticQuestion.Contradiction.ToLower()}.",
            "warrior" => $"Despite the main character's attempts to find constructive uses of the problem, the problem persists. They interact with the theme of {dramaticQuestion.Name.ToLower()} by demonstrating {dramaticQuestion.Negation.ToLower()}.",
            "martyr" => $"Finally, the main character demonstrates {dramaticQuestion.Positive.ToLower()} and successfully handles the problem by exercising power, and taking full responsibility for their decisions.",
            _ => throw new ArgumentException(message: "invalid completion type value", paramName: nameof(characterStage)),
        };
    }
}