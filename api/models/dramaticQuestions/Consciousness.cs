using System;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.DramaticQuestions;

public class Consciousness : IDramaticQuestion
{
    public string Id { get { return "consciousness"; } }
    public string Name { get { return "Consciousness"; } }
    public string Description { get { return "Is the risk of eternal damnation worth existing in the first place?"; } }
    public string Contrary { get { return "Unconsciousness"; } }
    public string Contradiction { get { return "Death"; } }
    public string Negation { get { return "Damnation"; } }
    public string Positive { get { return "Consciousness"; } }

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
        return $"The overarching theme of this story is asking if the risk of eternal damnation is worth existing in the first place.";
    }

}