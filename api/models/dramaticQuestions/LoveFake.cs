using System;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.DramaticQuestions;

public class LoveFake : IDramaticQuestion
{
    public string Id { get { return "loveFake"; } }
    public string Name { get { return "Faking Love"; } }
    public string Description { get { return "Can faking love lead to real love?"; } }

    public string Contrary { get { return "Indifference"; } }
    public string Contradiction { get { return "Hate"; } }
    public string Negation { get { return "Hatred masquerading as love"; } }
    public string Positive { get { return "Love"; } }

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
        return $"The overarching theme of this story is asking if faking love can lead to real love.";
    }

}