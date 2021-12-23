using System;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.ProblemTemplates;

public class FoolTriumphant : IProblemTemplate
{
    public string Id { get { return "foolTriumphant"; } }
    public string Name { get { return "Fool Triumphant"; } }
    public string Description { get { return "An innocent hero must defeat the prejudices of a group while maintaining their identity and avoiding the easy path of conformity."; } }
    public List<string> Keywords
    {
        get
        {
            return new List<string>{
        "Fool", "Establishment", "Transmutation"
    };
        }
    }

    public string GetLogLineContribution(IGenre genre, IArchetype heroArchetype, IArchetype enemyArchetype, IPrimalStakes primalStakes, IDramaticQuestion dramaticQuestion)
    {
        return "Fool Triumphant LogLine prompt contribution...";
    }

}