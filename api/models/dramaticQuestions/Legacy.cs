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
            };
        }
    }

    public string GetLogLineContribution(long seed, string CompletionType, IGenre genre, IProblemTemplate problemTemplate, IArchetype heroArchetype, IArchetype enemyArchetype, IPrimalStakes primalStakes)
    {
        return $"The overarching theme of this story is asking if a destructive legacy is better than no legacy at all.";
    }

}