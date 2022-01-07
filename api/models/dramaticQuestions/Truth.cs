using System;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.DramaticQuestions;

public class Truth : IDramaticQuestion
{
    public string Id { get { return "truth"; } }
    public string Name { get { return "Truth"; } }
    public string Description { get { return "Can self-deception reveal the truth?"; } }

    public string Contrary { get { return "White lies and half-truths"; } }
    public string Contradiction { get { return "Lies"; } }
    public string Negation { get { return "Self-deception"; } }
    public string Positive { get { return "Truth"; } }

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