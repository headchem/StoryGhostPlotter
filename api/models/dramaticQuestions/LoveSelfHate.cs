using System;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.DramaticQuestions;

public class LoveSelfHate : IDramaticQuestion
{
    public string Id { get { return "loveSelfHate"; } }
    public string Name { get { return "Self-hate"; } }
    public string Description { get { return "Can self-hate lead to love?"; } }

    public string Contrary { get { return "Indifference"; } }
    public string Contradiction { get { return "Hate"; } }
    public string Negation { get { return "Self-Hate"; } }
    public string Positive { get { return "Love"; } }

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
        return $"The overarching theme of this story is asking if self-hate can lead to love.";
    }

}