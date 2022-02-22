using System;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.DramaticQuestions;

public class Maturity : IDramaticQuestion
{
    public string Id { get { return "maturity"; } }
    public string Name { get { return "Maturity"; } }
    public string Description { get { return "Can faking maturity lead to real maturity?"; } }

    public string Contrary { get { return "Childishness"; } }
    public string Contradiction { get { return "Immaturity"; } }
    public string Negation { get { return "Immaturity perceived as maturity"; } }
    public string Positive { get { return "Maturity"; } }

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

    public string GetLogLineContribution(long seed, IGenre genre, IProblemTemplate problemTemplate)
    {
        return $"The overarching theme of this story is asking if faking maturity can lead to real maturity.";
    }

}