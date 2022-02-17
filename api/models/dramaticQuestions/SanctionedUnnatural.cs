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

    public AdviceSequence AdviceSequence
    {
        get
        {
            return new AdviceSequence
            {
            };
        }
    }

    public string GetLogLineContribution(long seed, IGenre genre, IProblemTemplate problemTemplate, IArchetype heroArchetype, IArchetype enemyArchetype, IPrimalStakes primalStakes)
    {
        return $"The overarching theme of this story is asking if unsanctioned behavior can be accepted as natural.";
    }

}