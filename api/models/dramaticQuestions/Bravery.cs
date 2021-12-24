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

    public string GetLogLineContribution(int seed, IGenre genre, IProblemTemplate problemTemplate, IArchetype heroArchetype, IArchetype enemyArchetype, IPrimalStakes primalStakes)
    {
        return "Bravery LogLine prompt contribution...";
    }

}