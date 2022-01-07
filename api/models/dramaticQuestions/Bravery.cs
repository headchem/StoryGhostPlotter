using System;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.DramaticQuestions;

public class Bravery : IDramaticQuestion
{
    public string Id { get { return "bravery"; } }
    public string Name { get { return "Bravery"; } }
    public string Description { get { return "Can faking bravery lead to true bravery?"; } }
    public string Contrary { get { return "Fear"; } }
    public string Contradiction { get { return "Cowardice"; } }
    public string Negation { get { return "Cowardice perceived as bravery"; } }
    public string Positive { get { return "Bravery"; } }

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