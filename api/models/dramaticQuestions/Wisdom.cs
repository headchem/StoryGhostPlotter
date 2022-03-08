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
                    ThemeStated = $"Subtly pose the dramatic question of \"{Description}\". The Hero doesn't have the experience or context yet to understand this theme of {Name.ToLower()}.",
                    Debate = $"The main character shows {Contrary.ToLower()}.",
                    FunAndGames = $"The main character shows {Contradiction.ToLower()}.",
                    DarkNightOfTheSoul = $"The main character shows {Negation.ToLower()}.",
                    Climax = $"The main character shows {Positive.ToLower()}."
                },
                Context = new AdviceSequence
                {

                }
            };
        }
    }

    public string GetLogLineContribution(long seed, IProblemTemplate problemTemplate)
    {
        return $"The overarching theme of this story is asking if faking intelligence can lead to true wisdom.";
    }

}