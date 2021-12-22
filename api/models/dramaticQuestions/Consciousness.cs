using System;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.DramaticQuestions;

public class Consciousness: IDramaticQuestion
{
    public string Id { get { return "consciousness"; } }
    public string Name { get { return "Consciousness"; } }
    public string Description { get { return "Consciousness desc here"; } }

    public string GetLogLineContribution(IGenre genre, IProblemTemplate problemTemplate, IArchetype heroArchetype, IArchetype enemyArchetype, IPrimalStakes primalStakes) {
        return "Consciousness LogLine promp contribution...";
    }

}