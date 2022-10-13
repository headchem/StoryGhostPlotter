using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class GirlsDisguisedAsBoys : IAppealTerm
{
    public string Id { get { return "GirlsDisguisedAsBoys"; } }
    public string Name { get { return "Girls disguised as boys"; } }
    public string Description { get { return "Seeking opportunities denied to them, these girls and women cross-dress out of necessity."; } }
    public List<string> Genres { get { return new List<string> { "adventure", "comedy", "drama", "romance", "history" }; } }
    public List<string> Types { get { return new List<string> { "Historical" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}