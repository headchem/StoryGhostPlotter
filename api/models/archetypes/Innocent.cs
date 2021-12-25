using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;
using StoryGhost.Enums;

namespace StoryGhost.Models.Archetypes;

public class Innocent : IArchetype
{
    public string Id { get { return "innocent"; } }
    public string Name { get { return "Innocent"; } }
    public string Description { get { return "The Innocent is optimistic and trusting that the future is bright, endearing them to others. They have a child-like spontaneity to start any journey. Prone to naiveté, they are blind to their own weaknesses, and become dependent on others to accomplish their goals. They fear abandonment and seek safety."; } }
    public string SourceOfMotivation { get { return SourceOfMotivationEnum.Themselves; } }
    public string OrphanDesires { get { return "Be happy, remain in safety, get to paradise."; } }
    public string WandererResponse { get { return "Deny it or seek rescue."; } }
    public string WarriorResponse { get { return "Do things right, loyally endangers self, discernment."; } }
    public List<string> GreatestFears
    {
        get
        {
            return new List<string>{
                "to be punished for doing something bad/wrong", "abandonment"
            };
        }
    }
    public List<string> Talents
    {
        get
        {
            return new List<string> {
                "optimism", "trust", "hope", "faith", "simplicity"
            };
        }
    }
    public List<string> Weaknesses
    {
        get
        {
            return new List<string> {
                "boring for all their innocence", "naiveté", "childish dependence", "denial", "obliviousness"
            };
        }
    }
    public string AddictiveQuality { get { return "denial"; } }
    public List<string> Addictions
    {
        get
        {
            return new List<string>{
                "consumerism", "sugar", "cheerfulness"
            };
        }
    }
    public string ShadowSide { get { return "Addicted to feeling good, the Innocent represses and denies the genuine hurt of self or others. They show excessive deference to others, even if they know better."; } }
    public List<string> Examples
    {
        get
        {
            return new List<string>{
                "uopian", "traditionalist", "naive", "mystic", "saint", "romantic", "dreamer"
            };
        }
    }
    public string Motto { get { return "Free to be you and me."; } }




    public string GetHeroLogLineContribution(int seed, IGenre genre, IProblemTemplate problemTemplate, IArchetype enemyArchetype, IPrimalStakes primalStakes, IDramaticQuestion dramaticQuestion)
    {
        return $"HERO has a {Name} personality (for example: {string.Join(", ", Examples)}).";
    }
    public string GetEnemyLogLineContribution(int seed, IGenre genre, IProblemTemplate problemTemplate, IArchetype heroArchetype, IPrimalStakes primalStakes, IDramaticQuestion dramaticQuestion)
    {
        return $"ENEMY has a {Name} personality (for example: {string.Join(", ", Examples)}).";
    }
}