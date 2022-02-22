using System;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.DramaticQuestions;

public class Truth : IDramaticQuestion
{
    public string Id { get { return "truth"; } }
    public string Name { get { return "Truth"; } }
    public string Description { get { return "Can self-deception reveal the truth?"; } }

    public string Contrary { get { return "White lies and half-truths"; } }
    public string Contradiction { get { return "Dishonesty"; } }
    public string Negation { get { return "Self-deception"; } }
    public string Positive { get { return "Truth"; } }

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
        return $"The overarching theme of this story is asking if self-deception can reveal the truth.";
    }

}