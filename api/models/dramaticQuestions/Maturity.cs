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