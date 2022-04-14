using System;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.DramaticQuestions;

public class Wisdom : IDramaticQuestion
{
    public string Id { get { return "wisdom"; } }
    public string Name { get { return "Wisdom"; } }
    public string Description { get { return "Can faking intelligence lead to true wisdom?"; } }

    public string Contrary { get { return "Ignorance"; } }
    public string Contradiction { get { return "Stupidity"; } }
    public string Negation { get { return "Stupidity perceived as intelligence"; } }
    public string Positive { get { return "Wisdom"; } }

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
        return $"The overarching theme of this story is asking if faking intelligence can lead to true wisdom.";
    }

}