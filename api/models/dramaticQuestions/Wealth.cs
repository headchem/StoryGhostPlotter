using System;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.DramaticQuestions;

public class Wealth : IDramaticQuestion
{
    public string Id { get { return "wealth"; } }
    public string Name { get { return "Wealth"; } }
    public string Description { get { return "Does money buy happiness?"; } }

    public string Contrary { get { return "Middle-class, just enough, average"; } }
    public string Contradiction { get { return "Poor and suffering the pains of poverty"; } }
    public string Negation { get { return "Rich but suffering the pains of poverty"; } }
    public string Positive { get { return "Wealth"; } }

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

    public string GetLogLineContribution(long seed, IProblemTemplate problemTemplate)
    {
        return $"The overarching theme of this story is asking if money can buy happiness.";
    }

}