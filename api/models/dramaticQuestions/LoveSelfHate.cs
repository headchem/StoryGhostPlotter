using System;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.DramaticQuestions;

public class LoveSelfHate : IDramaticQuestion
{
    public string Id { get { return "loveSelfHate"; } }
    public string Name { get { return "Self-hate"; } }
    public string Description { get { return "Can self-hate lead to love?"; } }

    public string Contrary { get { return "Indifference"; } }
    public string Contradiction { get { return "Hate"; } }
    public string Negation { get { return "Self-Hate"; } }
    public string Positive { get { return "Love"; } }

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
        return $"The overarching theme of this story is asking if self-hate can lead to love.";
    }

}