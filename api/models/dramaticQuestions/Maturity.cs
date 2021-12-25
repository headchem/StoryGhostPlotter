using System;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.DramaticQuestions;

public class Maturity : IDramaticQuestion
{
    public string Id { get { return "maturity"; } }
    public string Name { get { return "Maturity"; } }
    public string Description { get { return "Can faking maturity lead to real maturity?"; } }

    public string Contrary { get { return "Childishness"; } }
    public string Contradiction { get { return "Immaturity"; } }
    public string Negation { get { return "Immaturity perceived as maturity"; } }
    public string Positive { get { return "Maturity"; } }

    public string GetLogLineContribution(int seed, IGenre genre, IProblemTemplate problemTemplate, IArchetype heroArchetype, IArchetype enemyArchetype, IPrimalStakes primalStakes)
    {
        return $"The theme of the story is {Name}, which asks the dramatic question of \"{Description}\"";
    }

}