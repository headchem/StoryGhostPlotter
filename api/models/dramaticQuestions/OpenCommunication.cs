using System;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.DramaticQuestions;

public class OpenCommunication : IDramaticQuestion
{
    public string Id { get { return "openCommunication"; } }
    public string Name { get { return "Open Communication"; } }
    public string Description { get { return "Can babbling nonsense clearly communicate an important idea?"; } }

    public string Contrary { get { return "Alienation"; } }
    public string Contradiction { get { return "Isolation"; } }
    public string Negation { get { return "Insanity"; } }
    public string Positive { get { return "Open Communication"; } }

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
        return $"The overarching theme of this story is asking if babbling nonsense can ultimately communicate an important idea.";
    }

}