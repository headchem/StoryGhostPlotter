using System;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.DramaticQuestions;

public class NaturalUnsanctioned : IDramaticQuestion
{
    public string Id { get { return "naturalUnsanctioned"; } }
    public string Name { get { return "Natural, unsanctioned behavior"; } }
    public string Description { get { return "Can unnatural behavior be sanctioned?"; } }

    public string Contrary { get { return "Unnatural but sanctioned behavior"; } }
    public string Contradiction { get { return "Unnatural Behavior"; } }
    public string Negation { get { return "Grotesque and abhorrent behavior"; } }
    public string Positive { get { return "Natural Behavior"; } }

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
        return $"The overarching theme of this story is asking if unnatural behavior can ultimately be sanctioned.";
    }

}