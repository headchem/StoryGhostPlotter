using System;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.DramaticQuestions;

public class NaturalUnsanctioned : IDramaticQuestion
{
    public string Id { get { return "naturalUnsanctioned"; } }
    public string Name { get { return "Natural but unsanctioned behavior"; } }
    public string Description { get { return "Can unnatural behavior be sanctioned?"; } }

    public string Contrary { get { return "Unnatural but sanctioned behavior"; } }
    public string Contradiction { get { return "Unnatural Behavior"; } }
    public string Negation { get { return "Grotesque and abhorrent behavior"; } }
    public string Positive { get { return "Natural Behavior"; } }

    public string GetLogLineContribution(int seed, IGenre genre, IProblemTemplate problemTemplate, IArchetype heroArchetype, IArchetype enemyArchetype, IPrimalStakes primalStakes)
    {
        return $"The theme of the story is {Name}, which asks the dramatic question of \"{Description}\"";
    }

}