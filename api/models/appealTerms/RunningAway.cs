using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class RunningAway : IAppealTerm
{
    public string Id { get { return "RunningAway"; } }
    public string Name { get { return "Running away"; } }
    public string Description { get { return "Escape, adventure, a personal mission - these stories all feature runaways."; } }
    public List<string> Genres { get { return new List<string> { "action", "adventure", "family", "thriller", "urban" }; } }
    public List<string> Categories { get { return new List<string> { "Life's Challenges" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}