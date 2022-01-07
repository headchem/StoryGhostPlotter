using System;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.DramaticQuestions;

public class Consciousness : IDramaticQuestion
{
    public string Id { get { return "consciousness"; } }
    public string Name { get { return "Consciousness"; } }
    public string Description { get { return "Is the risk of eternal damnation worth existing in the first place?"; } }
    public string Contrary { get { return "Unconsciousness"; } }
    public string Contradiction { get { return "Death"; } }
    public string Negation { get { return "Damnation"; } }
    public string Positive { get { return "Consciousness"; } }

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