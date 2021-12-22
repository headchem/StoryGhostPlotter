using System;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.DramaticQuestions;

public class Bravery: IDramaticQuestion
{
    public string Id { get { return "bravery"; } }
    public string Name { get { return "Bravery"; } }
    public string Description { get { return "Bravery desc here"; } }

    public string GetLogLineContribution(IGenre genre, IProblemTemplate problemTemplate, IArchetype heroArchetype, IArchetype enemyArchetype, IPrimalStakes primalStakes) {
        return "Bravery LogLine prompt contribution...";
    }

}