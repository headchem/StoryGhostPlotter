using System;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.DramaticQuestions;

public class Loyalty : IDramaticQuestion
{
    public string Id { get { return "loyalty"; } }
    public string Name { get { return "Loyalty"; } }
    public string Description { get { return "Can you be loyal to others if you betray yourself?"; } }

    public string Contrary { get { return "Split Allegiance"; } }
    public string Contradiction { get { return "Betrayal"; } }
    public string Negation { get { return "Self-Betrayal"; } }
    public string Positive { get { return "Loyalty"; } }

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