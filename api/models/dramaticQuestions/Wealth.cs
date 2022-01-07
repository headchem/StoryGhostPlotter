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
        var curAnswer = getCompletionTypeAnswer(CompletionType);
        
        return $"At this point in this griping tale, the main character answers the emotional question of \"{Description}\" with: {curAnswer}.";
    }

    public string getCompletionTypeAnswer(string completionType) {
        if (completionType.Contains("orphan")) return Contrary;
        if (completionType.Contains("wanderer")) return Contradiction;
        if (completionType.Contains("warrior")) return Negation;
        if (completionType.Contains("martyr")) return Positive;

        throw new Exception($"CompletionType: {completionType} not found");
    }

}