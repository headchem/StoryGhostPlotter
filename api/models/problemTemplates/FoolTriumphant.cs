using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.ProblemTemplates;

public class FoolTriumphant : IProblemTemplate
{
    public string Id { get { return "foolTriumphant"; } }
    public string Name { get { return "Fool Triumphant"; } }
    public string Description { get { return "An innocent hero must defeat the prejudices of a group while maintaining their identity and avoiding the easy path of conformity."; } }
    public List<string> Keywords
    {
        get
        {
            return new List<string>{
                "fool", "establishment", "transmutation"
            };
        }
    }

    public string OpeningImage { get { return ""; } }
    public string ThemeStated { get { return ""; } }
    public string Setup { get { return "The underdog Hero appears to be the Village Idiot, but there is a spark of wisdom within them."; } }
    public string IncitingIncident { get { return "A bigger, more powerful, \"establishment\" Enemy is cruel to the Hero and discounts them due to the Hero's uniqueness."; } }
    public string Debate { get { return ""; } }
    public string BreakIntoTwo { get { return "The Hero decides they have had enough of society deeming them to be a loser because of their uniqueness."; } }
    public string FunAndGames { get { return "The Hero has a friendly accomplice who watches in disbelief as the Hero takes on the Enemy."; } }
    public string FirstPinchPoint { get { return ""; } }
    public string Midpoint { get { return "The Hero suceeds at shaming the Enemy establishment that shunned them."; } }
    public string BadGuysCloseIn { get { return "The Hero may have succeeded, but they did so by sacrificing or downplaying their uniqueness."; } }
    public string SecondPinchPoint { get { return ""; } }
    public string AllHopeIsLost { get { return ""; } }
    public string DarkNightOfTheSoul { get { return "The Hero admits they have become no better than the Enemy establishment that shunned them in the first place."; } }
    public string BreakIntoThree { get { return ""; } }
    public string Climax { get { return "The Hero embraces their uniqueness and uses it to overcome the Problem."; } }
    public string Cooldown { get { return ""; } }

public Adjectives OrphanAdjectives
    {
        get
        {
            return new Adjectives
            {
                HeroAdjective = "Innocent",
                EnemyAdjective = "Ridiculing"
            };
        }
    }

    public Adjectives WandererAdjectives
    {
        get
        {
            return new Adjectives
            {
                HeroAdjective = "Innocent",
                EnemyAdjective = "Ridiculing"
            };
        }
    }

    public Adjectives WarriorAdjectives
    {
        get
        {
            return new Adjectives
            {
                HeroAdjective = "Confident",
                EnemyAdjective = "Respectful"
            };
        }
    }

    public Adjectives MartyrAdjectives
    {
        get
        {
            return new Adjectives
            {
                HeroAdjective = "Confident",
                EnemyAdjective = "Ridiculing"
            };
        }
    }

    public string GetLogLineContribution(int seed, IGenre genre, IArchetype heroArchetype, IArchetype enemyArchetype, IPrimalStakes primalStakes, IDramaticQuestion dramaticQuestion)
    {
        return $"This is a {Name} story about the ideas of: {string.Join(", ", Keywords)}.";
    }

}