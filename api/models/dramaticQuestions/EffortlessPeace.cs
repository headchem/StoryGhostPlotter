using System;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.DramaticQuestions;

public class EffortlessPeace : IDramaticQuestion
{
    public string Id { get { return "effortlessPeace"; } }
    public string Name { get { return "Effortless Peace"; } }
    public string Description { get { return "Is effort required to attain peace?"; } }
    public string Contrary { get { return "Consciously attempting to ignore strife"; } }
    public string Contradiction { get { return "Exertion to gain peace"; } }
    public string Negation { get { return "Exertion leading to strife"; } }
    public string Positive { get { return "Effortless peace"; } }

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