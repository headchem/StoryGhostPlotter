using System;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.DramaticQuestions;

public class Liberty : IDramaticQuestion
{
    public string Id { get { return "liberty"; } }
    public string Name { get { return "Liberty"; } }
    public string Description { get { return "Can freedom be found in slavery?"; } }

    public string Contrary { get { return "Restraint"; } }
    public string Contradiction { get { return "Slavery"; } }
    public string Negation { get { return "Slavery perceived as freedom"; } }
    public string Positive { get { return "Liberty"; } }

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
        return $"The overarching theme of this story is asking if freedom can be found in slavery.";
    }

}