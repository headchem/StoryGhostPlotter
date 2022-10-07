using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class RagsToRiches : IAppealTerm
{
    public string Id { get { return "RagsToRiches"; } }
    public string Name { get { return "Rags to riches"; } }
    public string Description { get { return "Wealth and fame await characters from humble beginnings."; } }
    public List<string> Genres { get { return new List<string> { "action", "adventure", "comedy", "crime", "drama", "romance" }; } }
    public List<string> Types { get { return new List<string> { "Concepts and Characters" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}