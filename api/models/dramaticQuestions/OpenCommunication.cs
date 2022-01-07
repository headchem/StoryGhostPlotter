using System;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.DramaticQuestions;

public class OpenCommunication : IDramaticQuestion
{
    public string Id { get { return "openCommunication"; } }
    public string Name { get { return "Open Communication"; } }
    public string Description { get { return "Can babbling nonsense clearly communicate an important idea?"; } }

    public string Contrary { get { return "Alienation"; } }
    public string Contradiction { get { return "Isolation"; } }
    public string Negation { get { return "Insantiy"; } }
    public string Positive { get { return "Open Communication"; } }

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