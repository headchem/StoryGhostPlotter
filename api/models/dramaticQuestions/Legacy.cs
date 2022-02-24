using System;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.DramaticQuestions;

public class Legacy : IDramaticQuestion
{
    public string Id { get { return "legacy"; } }
    public string Name { get { return "Legacy"; } }
    public string Description { get { return "Is a destructive legacy better than no legacy?"; } }
    public string Contrary { get { return "Build a problematic legacy"; } }
    public string Contradiction { get { return "Throw away one's legacy"; } }
    public string Negation { get { return "Having a destructive legacy while thinking it's positive"; } }
    public string Positive { get { return "Build a positive legacy"; } }

    public AdviceSequence AdviceSequence
    {
        get
        {
            return new AdviceSequence
            {
                ThemeStated = $"Subtly pose the dramatic question of \"{Description}\". The Hero doesn't have the experience or context yet to understand this theme of {Name.ToLower()}.",
                Debate = $"The main character shows {Contrary.ToLower()}.",
                FunAndGames = $"The main character shows {Contradiction.ToLower()}.",
                DarkNightOfTheSoul = $"The main character shows {Negation.ToLower()}.",
                Climax = $"The main character shows {Positive.ToLower()}."
            };
        }
    }

    public string GetLogLineContribution(long seed, IProblemTemplate problemTemplate)
    {
        return $"The overarching theme of this story is asking if a destructive legacy is better than no legacy at all.";
    }

}