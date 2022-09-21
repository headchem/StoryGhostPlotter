using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class SidekickSpotlight : IAppealTerm
{
    public string Id { get { return "SidekickSpotlight"; } }
    public string Name { get { return "Sidekick spotlight"; } }
    public string Description { get { return "Sidekicks get a promotion."; } }
    public List<string> Genres { get { return new List<string> { "" }; } }
    public List<string> Types { get { return new List<string> { "" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}