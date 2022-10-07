using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class ThrownTogether : IAppealTerm
{
    public string Id { get { return "ThrownTogether"; } }
    public string Name { get { return "Thrown together"; } }
    public string Description { get { return "Forging connections in unexpected ways."; } }
    public List<string> Genres { get { return new List<string> { "adventure", "comedy", "drama", "romance", "sports", "thriller", "urban", "war", "western" }; } }
    public List<string> Types { get { return new List<string> { "Concepts and Characters" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}