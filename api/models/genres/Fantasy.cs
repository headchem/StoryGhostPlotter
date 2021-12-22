using System;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.Genres;

public class Fantasy : IGenre
{
    public string Id { get { return "fantasy"; } }
    public string Name { get { return "Fantasy"; } }
    public string Description { get { return "Fantasy desc here"; } }

    public string GetLogLineContribution(IProblemTemplate problemTemplate, IArchetype heroArchetype, IArchetype enemyArchetype, IPrimalStakes primalStakes, IDramaticQuestion dramaticQuestion)
    {
        return "Fantasy LogLine prompt contribution...";
    }

}