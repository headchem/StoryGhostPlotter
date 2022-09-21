using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class TweenRomance : IAppealTerm
{
    public string Id { get { return "TweenRomance"; } }
    public string Name { get { return "Tween romance"; } }
    public string Description { get { return "First dates, all-consuming crushes, and emerging romantic feelings hold sway."; } }
    public List<string> Genres { get { return new List<string> { "" }; } }
    public List<string> Types { get { return new List<string> { "" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}