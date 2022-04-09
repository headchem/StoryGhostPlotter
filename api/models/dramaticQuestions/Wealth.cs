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

    public SequenceAdvices AdviceSequence
    {
        get
        {
            return new SequenceAdvices
            {
                Events = new AdviceSequence
                {
                    ThemeStated = $"Subtly pose the dramatic question of \"{Description}\"",
                    Debate = $"The main character shows {Contrary.ToLower()}.",
                    FunAndGames = $"The main character shows {Contradiction.ToLower()}.",
                    BadGuysCloseIn = $"The main character shows {Negation.ToLower()}.",
                    Climax = $"The main character shows {Positive.ToLower()}."
                },
                Context = new AdviceSequence
                {
                    ThemeStated = $"The main character doesn't have the experience or context yet to understand the theme of {Name.ToLower()}."
                }
            };
        }
    }

    public string GetLogLineContribution(long seed, IProblemTemplate problemTemplate)
    {
        return $"The overarching theme of this story is asking if money can buy happiness.";
    }

}