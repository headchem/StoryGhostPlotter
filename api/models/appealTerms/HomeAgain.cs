using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class HomeAgain : IAppealTerm
{
    public string Id { get { return "HomeAgain"; } }
    public string Name { get { return "Home again"; } }
    public string Description { get { return "Coming back to the place you left behind."; } }
    public List<string> Genres { get { return new List<string> { "romance" }; } }
    public List<string> Types { get { return new List<string> { "Setting" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}