using System;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.DramaticQuestions;

public class Success : IDramaticQuestion
{
    public string Id { get { return "success"; } }
    public string Name { get { return "Success"; } }
    public string Description { get { return "Is selling out truly a form of success?"; } }

    public string Contrary { get { return "Compromise"; } }
    public string Contradiction { get { return "Failure"; } }
    public string Negation { get { return "Selling Out"; } }
    public string Positive { get { return "Success"; } }

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
        return $"The overarching theme of this story is asking if selling out can be a form of success.";
    }

}