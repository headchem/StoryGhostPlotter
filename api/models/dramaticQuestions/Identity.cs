using System;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.DramaticQuestions;

public class Identity : IDramaticQuestion
{
    public string Id { get { return "identity"; } }
    public string Name { get { return "Identity"; } }
    public string Description { get { return "What makes someone's identity unique, and where do they fit in?"; } }

    public string Contrary { get { return "Recognizing your identity doesn't fit in"; } }
    public string Contradiction { get { return "Being ashamed of your identity"; } }
    public string Negation { get { return "Adopting an identity that isn't yours"; } }
    public string Positive { get { return "Being proud of your unique identity"; } }

    public string GetLogLineContribution(int seed, string CompletionType, IGenre genre, IProblemTemplate problemTemplate, IArchetype heroArchetype, IArchetype enemyArchetype, IPrimalStakes primalStakes)
    {
        return $"The overarching theme of this story is that of accepting one's unique identity.";
    }

}