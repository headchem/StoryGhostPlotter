using System;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.DramaticQuestions;

public class NaturalUnsanctioned : IDramaticQuestion
{
    public string Id { get { return "naturalUnsanctioned"; } }
    public string Name { get { return "Natural, unsanctioned behavior"; } }
    public string Description { get { return "Can unnatural behavior be sanctioned?"; } }

    public string Contrary { get { return "Unnatural but sanctioned behavior"; } }
    public string Contradiction { get { return "Unnatural Behavior"; } }
    public string Negation { get { return "Grotesque and abhorrent behavior"; } }
    public string Positive { get { return "Natural Behavior"; } }

    public SequenceAdvices AdviceSequence
    {
        get
        {
            return new SequenceAdvices
            {
                Events = new AdviceSequence
                {
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
        return $"The overarching theme of this story is asking if unnatural behavior can ultimately be sanctioned.";
    }

}