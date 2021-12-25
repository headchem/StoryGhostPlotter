using System;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.DramaticQuestions;

public class SanctionedUnnatural : IDramaticQuestion
{
    public string Id { get { return "sanctionedUnnatural"; } }
    public string Name { get { return "Sanctioned but unnatural behavior"; } }
    public string Description { get { return "Can unsanctioned behavior be natural?"; } }

    public string Contrary { get { return "Unsanctioned but natural behavior"; } }
    public string Contradiction { get { return "Unsanctioned Behavior"; } }
    public string Negation { get { return "Grotesque and abhorrent behavior"; } }
    public string Positive { get { return "Sanctioned Behavior"; } }

    public string GetLogLineContribution(int seed, IGenre genre, IProblemTemplate problemTemplate, IArchetype heroArchetype, IArchetype enemyArchetype, IPrimalStakes primalStakes)
    {
        return $"The theme of the story is {Name}, which asks the dramatic question of \"{Description}\"";
    }

}