using System;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.DramaticQuestions;

public class Wealth : IDramaticQuestion
{
    public string Id { get { return "wealth"; } }
    public string Name { get { return "Wealth"; } }
    public string Description { get { return "Does money buy happiness?"; } }

    public string Contrary { get { return "Middle-class, just enough, average"; } }
    public string Contradiction { get { return "Poor and suffering the pains of poverty"; } }
    public string Negation { get { return "Rich but suffering the pains of poverty"; } }
    public string Positive { get { return "Wealth"; } }

    public string GetLogLineContribution(int seed, string CompletionType, IGenre genre, IProblemTemplate problemTemplate, IArchetype heroArchetype, IArchetype enemyArchetype, IPrimalStakes primalStakes)
    {
        return $"The overarching theme of this story is asking if money can buy happiness.";
    }

}