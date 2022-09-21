using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class CosmicHorror : IAppealTerm
{
    public string Id { get { return "CosmicHorror"; } }
    public string Name { get { return "Cosmic horror"; } }
    public string Description { get { return "Look here for horror beyond human understanding."; } }
    public List<string> Genres { get { return new List<string> { "" }; } }
    public List<string> Types { get { return new List<string> { "" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}