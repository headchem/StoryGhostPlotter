using System;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.DramaticQuestions;

public class SanctionedUnnatural : IDramaticQuestion
{
    public string Id { get { return "sanctionedUnnatural"; } }
    public string Name { get { return "Sanctioned, unnatural behavior"; } }
    public string Description { get { return "Can unsanctioned behavior be natural?"; } }

    public string Contrary { get { return "Unsanctioned but natural behavior"; } }
    public string Contradiction { get { return "Unsanctioned Behavior"; } }
    public string Negation { get { return "Grotesque and abhorrent behavior"; } }
    public string Positive { get { return "Sanctioned Behavior"; } }

    public SequenceAdvices AdviceSequence
    {
        get
        {
            return new SequenceAdvices
            {
                Events = new AdviceSequence
                {
                    ThemeStated = $"Subtly pose the dramatic question of \"{Description}\"",
                    BStory = $"A love interest or mentor will challenge and nurture the protagonist in their spiritual journey to embrace the theme of {Name.ToLower()}.",
                    Debate = $"The main character shows {Contrary.ToLower()}.",
                    FunAndGames = $"The main character shows {Contradiction.ToLower()}.",
                    BadGuysCloseIn = $"The main character shows {Negation.ToLower()}.",
                    Climax = $"The main character shows {Positive.ToLower()}."
                },
                Context = new AdviceSequence
                {
                    ThemeStated = $"The main character doesn't have the experience or context yet to understand the theme of {Name.ToLower()}.",
                }
            };
        }
    }

    public string GetLogLineContribution(long seed, IProblemTemplate problemTemplate)
    {
        return $"The overarching theme of this story is asking if unsanctioned behavior can be accepted as natural.";
    }

}