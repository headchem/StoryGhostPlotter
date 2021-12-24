using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.PrimalStakes;

public class ProtectPossession : IPrimalStakes
{
    public string Id { get { return "protectPossession"; } }
    public string Name { get { return "Protect Possession"; } }
    public string Description { get { return "The Hero possesses or desires a special object that gives their life meaning. An outsider threatens to destroy or steal the object, while the Hero will sacrifice everything to protect or acquire the object."; } }
    public List<string> Keywords
    {
        get
        {
            return new List<string>{
                "greed", "prize", "abundance", "covet", "possess"
            };
        }
    }

    public string GetLogLineContribution(int seed, IGenre genre, IProblemTemplate problemTemplate, IArchetype heroArchetype, IArchetype enemyArchetype, IDramaticQuestion dramaticQuestion)
    {
        return "Protect Possession LogLine prompt contribution...";
    }

}