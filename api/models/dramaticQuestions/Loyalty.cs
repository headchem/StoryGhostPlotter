using System;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.DramaticQuestions;

public class Loyalty : IDramaticQuestion
{
    public string Id { get { return "loyalty"; } }
    public string Name { get { return "Loyalty"; } }
    public string Description { get { return "Can you be loyal to others if you betray yourself?"; } }

    public string Contrary { get { return "Split Allegiance"; } }
    public string Contradiction { get { return "Betrayal"; } }
    public string Negation { get { return "Self-Betrayal"; } }
    public string Positive { get { return "Loyalty"; } }

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
        return $"The overarching theme of this story is asking if one can be loyal to others while betraying themselves.";
    }

}