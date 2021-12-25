using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.ProblemTemplates;

public class RitesOfPassage : IProblemTemplate
{
    public string Id { get { return "ritesOfPassage"; } }
    public string Name { get { return "Rites of Passage"; } }
    public string Description { get { return "A troubled hero must rise above an external crisis by defeating their own inner demons."; } }
    public List<string> Keywords
    {
        get
        {
            return new List<string>{
                "Life Problem", "Wrong Way", "Acceptance"
            };
        }
    }

    public string OpeningImage { get { return ""; } }
    public string ThemeStated { get { return "A vague outside force will bring pain and torment the Hero."; } }
    public string Setup { get { return ""; } }
    public string IncitingIncident { get { return "The outside force brings misery and misfortune upon the Hero, and the Hero struggles to name it."; } }
    public string Debate { get { return ""; } }
    public string BreakIntoTwo { get { return ""; } }
    public string FunAndGames { get { return "The unseen force continues to sneak up on the Hero, while the beleaguered Hero is distracted with shallower problems."; } }
    public string FirstPinchPoint { get { return ""; } }
    public string Midpoint { get { return "The Hero temporarily contains the invisible force, and falsely believes they are in control."; } }
    public string BadGuysCloseIn { get { return ""; } }
    public string SecondPinchPoint { get { return ""; } }
    public string AllHopeIsLost { get { return ""; } }
    public string DarkNightOfTheSoul { get { return ""; } }
    public string BreakIntoThree { get { return ""; } }
    public string Climax { get { return "The Hero is victorious by accepting their own humanity, surrendering and being at peace with the invisible forces of life they can't control."; } }
    public string Cooldown { get { return ""; } }

public Adjectives OrphanAdjectives
    {
        get
        {
            return new Adjectives
            {
                HeroAdjective = "Troubled",
                EnemyAdjective = "Doubtful"
            };
        }
    }

    public Adjectives WandererAdjectives
    {
        get
        {
            return new Adjectives
            {
                HeroAdjective = "Troubled",
                EnemyAdjective = "Doubtful"
            };
        }
    }

    public Adjectives WarriorAdjectives
    {
        get
        {
            return new Adjectives
            {
                HeroAdjective = "Successful",
                EnemyAdjective = "Hopeful"
            };
        }
    }

    public Adjectives MartyrAdjectives
    {
        get
        {
            return new Adjectives
            {
                HeroAdjective = "Successful",
                EnemyAdjective = "Doubtful"
            };
        }
    }

    public string GetLogLineContribution(int seed, IGenre genre, IArchetype heroArchetype, IArchetype enemyArchetype, IPrimalStakes primalStakes, IDramaticQuestion dramaticQuestion)
    {
        return $"This is a {Name} story about the ideas of: {string.Join(", ", Keywords)}.";
    }

}