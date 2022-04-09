using System;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.DramaticQuestions;

public class EffortlessPeace : IDramaticQuestion
{
    public string Id { get { return "effortlessPeace"; } }
    public string Name { get { return "Effortless Peace"; } }
    public string Description { get { return "Is effort required to attain peace?"; } }
    public string Contrary { get { return "Consciously attempting to ignore strife"; } }
    public string Contradiction { get { return "Exertion to gain peace"; } }
    public string Negation { get { return "Exertion leading to strife"; } }
    public string Positive { get { return "Effortless peace"; } }

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
        return $"The overarching theme of this story is asking if effort is required to attain peace.";
    }

}