using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class CourtIntrigue : IAppealTerm
{
    public string Id { get { return "CourtIntrigue"; } }
    public string Name { get { return "Court intrigue"; } }
    public string Description { get { return "Politics, alliances and betrayals in the royal court."; } }
    public List<string> Genres { get { return new List<string> { "fantasy", "history" }; } }
    public List<string> Types { get { return new List<string> { "Plot" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}