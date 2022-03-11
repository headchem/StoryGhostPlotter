using System;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.DramaticQuestions;

public class Bravery : IDramaticQuestion
{
    public string Id { get { return "bravery"; } }
    public string Name { get { return "Bravery"; } }
    public string Description { get { return "Can faking bravery lead to true bravery?"; } }
    public string Contrary { get { return "Fear"; } } // Opening Image, Theme Stated, Setup, Inciting Incident, 
    public string Contradiction { get { return "Cowardice"; } }
    public string Negation { get { return "Cowardice perceived as bravery"; } }
    public string Positive { get { return "Bravery"; } }

    public SequenceAdvices AdviceSequence
    {
        get
        {
            return new SequenceAdvices
            {
                Events = new AdviceSequence
                { // LEFT OFF: map the 4 stages to specific sequences, or ranges of sequences to help me describe them in more detail
                    ThemeStated = $"Subtly pose the dramatic question of \"{Description}\".",
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
        return $"The overarching theme of this story is that of faking bravery.";
    }
}