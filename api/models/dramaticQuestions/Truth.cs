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

    public string GetLogLineContribution(int seed, IGenre genre, IProblemTemplate problemTemplate, IArchetype heroArchetype, IArchetype enemyArchetype, IPrimalStakes primalStakes)
    {
        return $"The theme of the story is {Name}, which asks the dramatic question of \"{Description}\"";
    }

}