using System;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.DramaticQuestions;

public class Loyalty : IDramaticQuestion
{
    public string Id { get { return "loyalty"; } }
    public string Name { get { return "Loyalty"; } }
    public string Description { get { return "Can you be loyal to others if you betray yourself?"; } }

    public string Contrary { get { return "Split Allegiance"; } }
    public string Contradiction { get { return "Betrayal"; } }
    public string Negation { get { return "Self-Betrayal"; } }
    public string Positive { get { return "Loyalty"; } }

    public AdviceSequence AdviceSequence
    {
        get
        {
            return new AdviceSequence
            {
                ThemeStated = $"Subtly pose the dramatic question of \"{Description}\". The Hero doesn't have the experience or context yet to understand this theme of {Name.ToLower()}.",
                Debate = $"The main character shows {Contrary.ToLower()}.",
                FunAndGames = $"The main character shows {Contradiction.ToLower()}.",
                DarkNightOfTheSoul = $"The main character shows {Negation.ToLower()}.",
                Climax = $"The main character shows {Positive.ToLower()}."
            };
        }
    }

    public string GetLogLineContribution(long seed, IGenre genre, IProblemTemplate problemTemplate, IArchetype heroArchetype, IArchetype enemyArchetype, IPrimalStakes primalStakes)
    {
        return $"The overarching theme of this story is asking if one can be loyal to others while betraying themselves.";
    }

}