using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;
using StoryGhost.Enums;

namespace StoryGhost.Models.Archetypes;

public class Magician : IArchetype
{
    public string Id { get { return "magician"; } }
    public string Name { get { return "Magician"; } }
    public string Description { get { return "The Magician wishes to achieve a higher plane of existence by using the laws of the universe to transform situations, influence others, and turn their vision into reality. Wielding great power, they fear causing unintentional harm. Prone to using their power manulatively, they can myopically mistake having power as the end goal."; } }
    public string SourceOfMotivation { get { return SourceOfMotivationEnum.Balanced; } }
    public string OrphanDesires { get { return "Materialize dreams, transform, understand the fundamental laws of the universe."; } }
    public string WandererResponse { get { return "Transform the problem."; } }
    public string WarriorResponse { get { return "Develop a vision and live by it, align self with cosmos, wield power as a tool."; } }
    public List<string> GreatestFears
    {
        get
        {
            return new List<string>{
                "unintended negative consequences", "evil sorcery"
            };
        }
    }
    public List<string> Talents
    {
        get
        {
            return new List<string> {
                "finding win-win solutions", "personal power", "transformation", "catalytic", "healing power"
            };
        }
    }
    public List<string> Weaknesses
    {
        get
        {
            return new List<string> {
                "manipulation of others", "disconnection with reality", "cultist and guru-like"
            };
        }
    }
    public string AddictiveQuality { get { return "dishonesty via illusion"; } }
    public List<string> Addictions
    {
        get
        {
            return new List<string>{
                "power", "mind-altering substances"
            };
        }
    }
    public string ShadowSide { get { return "The Magician can become an evil sorcerer, transforming situations for the worse, or poisoning the thoughts of themself or others."; } }
    public List<string> Examples
    {
        get
        {
            return new List<string>{
                "visionary", "catalyst", "inventor", "charismatic leader", "shaman", "healer"
            };
        }
    }
    public string Motto { get { return "I make things happen."; } }




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