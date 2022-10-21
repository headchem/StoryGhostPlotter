using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class DealingWithBullies : IAppealTerm
{
    public string Id { get { return "DealingWithBullies"; } }
    public string Name { get { return "Dealing with bullies"; } }
    public string Description { get { return "It's a vicious cycle, affecting both the targets and instigators."; } }
    public List<string> Genres { get { return new List<string> { "drama", "family", "urban" }; } }
    public List<string> Categories { get { return new List<string> { "Family and Relationships" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}