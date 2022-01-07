using System;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.DramaticQuestions;

public class Liberty : IDramaticQuestion
{
    public string Id { get { return "liberty"; } }
    public string Name { get { return "Liberty"; } }
    public string Description { get { return "Can freedom be found in slavery?"; } }

    public string Contrary { get { return "Restraint"; } }
    public string Contradiction { get { return "Slavery"; } }
    public string Negation { get { return "Slavery perceived as freedom"; } }
    public string Positive { get { return "Liberty"; } }

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