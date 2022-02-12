using System;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.DramaticQuestions;

public class OpenCommunication : IDramaticQuestion
{
    public string Id { get { return "openCommunication"; } }
    public string Name { get { return "Open Communication"; } }
    public string Description { get { return "Can babbling nonsense clearly communicate an important idea?"; } }

    public string Contrary { get { return "Alienation"; } }
    public string Contradiction { get { return "Isolation"; } }
    public string Negation { get { return "Insantiy"; } }
    public string Positive { get { return "Open Communication"; } }

    public string GetLogLineContribution(long seed, string CompletionType, IGenre genre, IProblemTemplate problemTemplate, IArchetype heroArchetype, IArchetype enemyArchetype, IPrimalStakes primalStakes)
    {
        return $"The overarching theme of this story is asking if babbling nonsense can ultimately communicate an important idea.";
    }

}