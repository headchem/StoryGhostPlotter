using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class SpaceMilitary : IAppealTerm
{
    public string Id { get { return "SpaceMilitary"; } }
    public string Name { get { return "Space Military"; } }
    public string Description { get { return "Set across the skies. Military strategy, expertise, and armament. Detailed battle scenes. Mercenaries and officers alike play roles."; } }
    public List<string> Genres { get { return new List<string> { "science fiction" }; } }
    public List<string> Categories { get { return new List<string> { "Concepts and Characters" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}