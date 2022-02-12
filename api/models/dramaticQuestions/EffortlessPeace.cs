using System;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.DramaticQuestions;

public class EffortlessPeace : IDramaticQuestion
{
    public string Id { get { return "effortlessPeace"; } }
    public string Name { get { return "Effortless Peace"; } }
    public string Description { get { return "Is effort required to attain peace?"; } }
    public string Contrary { get { return "Consciously attempting to ignore strife"; } }
    public string Contradiction { get { return "Exertion to gain peace"; } }
    public string Negation { get { return "Exertion leading to strife"; } }
    public string Positive { get { return "Effortless peace"; } }

    public string GetLogLineContribution(long seed, string CompletionType, IGenre genre, IProblemTemplate problemTemplate, IArchetype heroArchetype, IArchetype enemyArchetype, IPrimalStakes primalStakes)
    {
        return $"The overarching theme of this story is asking if effort is required to attain peace.";
    }

}