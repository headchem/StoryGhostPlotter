using System;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.DramaticQuestions;

public class Wisdom : IDramaticQuestion
{
    public string Id { get { return "wisdom"; } }
    public string Name { get { return "Wisdom"; } }
    public string Description { get { return "Can faking intelligence lead to true wisdom?"; } }

    public string Contrary { get { return "Ignorance"; } }
    public string Contradiction { get { return "Stupidity"; } }
    public string Negation { get { return "Stupidity perceived as intelligence"; } }
    public string Positive { get { return "Wisdom"; } }

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