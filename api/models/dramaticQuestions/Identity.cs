using System;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.DramaticQuestions;

public class Identity : IDramaticQuestion
{
    public string Id { get { return "identity"; } }
    public string Name { get { return "Identity"; } }
    public string Description { get { return "What makes someone's identity unique, and where do they fit in?"; } }

    public string Contrary { get { return "Recognizing your identity doesn't fit in"; } }
    public string Contradiction { get { return "Being ashamed of your identity"; } }
    public string Negation { get { return "Adopting an identity that isn't yours"; } }
    public string Positive { get { return "Being proud of your unique identity"; } }

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
        return $"The overarching theme of this story is that of accepting one's unique identity.";
    }

}