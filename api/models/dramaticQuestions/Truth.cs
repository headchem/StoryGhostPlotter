using System;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.DramaticQuestions;

public class Truth : IDramaticQuestion
{
    public string Id { get { return "truth"; } }
    public string Name { get { return "Truth"; } }
    public string Description { get { return "Can self-deception reveal the truth?"; } }

    public string Contrary { get { return "White lies and half-truths"; } }
    public string Contradiction { get { return "Lies"; } }
    public string Negation { get { return "Self-deception"; } }
    public string Positive { get { return "Truth"; } }

    public string GetLogLineContribution(long seed, string CompletionType, IGenre genre, IProblemTemplate problemTemplate, IArchetype heroArchetype, IArchetype enemyArchetype, IPrimalStakes primalStakes)
    {
        return $"The overarching theme of this story is asking if self-deception can reveal the truth.";
    }

}