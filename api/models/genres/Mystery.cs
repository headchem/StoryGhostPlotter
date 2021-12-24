using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.Genres;

public class Mystery : IGenre
{
    public string Id { get { return "mystery"; } }
    public string Name { get { return "Mystery"; } }
    public string Description { get { return "Mystery explores a shocking event, usually a murder or crime. A small cast of suspects all have plausible motives. The big reveal of the true culprit is always a surprise."; } }
    public List<string> Keywords
    {
        get
        {
            return new List<string>{
                "puzzle", "suspense", "crime", "motives", "suspicion"
            };
        }
    }

    public string GetLogLineContribution(int seed, IProblemTemplate problemTemplate, IArchetype heroArchetype, IArchetype enemyArchetype, IPrimalStakes primalStakes, IDramaticQuestion dramaticQuestion)
    {
        return "Mystery LogLine prompt contribution...";
    }

}