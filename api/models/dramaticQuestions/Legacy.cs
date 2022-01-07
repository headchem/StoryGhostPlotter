using System;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.DramaticQuestions;

public class Legacy : IDramaticQuestion
{
    public string Id { get { return "legacy"; } }
    public string Name { get { return "Legacy"; } }
    public string Description { get { return "Is a destructive legacy better than no legacy?"; } }
    public string Contrary { get { return "Build a problematic legacy"; } }
    public string Contradiction { get { return "Throw away one's legacy"; } }
    public string Negation { get { return "Having a destructive legacy while thinking it's positive"; } }
    public string Positive { get { return "Build a positive legacy"; } }

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