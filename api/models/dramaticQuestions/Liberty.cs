using System;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.DramaticQuestions;

public class Liberty : IDramaticQuestion
{
    public string Id { get { return "liberty"; } }
    public string Name { get { return "Liberty"; } }
    public string Description { get { return "Can freedom be found in slavery?"; } }

    public string Contrary { get { return "Restraint"; } }
    public string Contradiction { get { return "Slavery"; } }
    public string Negation { get { return "Slavery perceived as freedom"; } }
    public string Positive { get { return "Liberty"; } }

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
        return $"The overarching theme of this story is asking if freedom can be found in slavery.";
    }

}