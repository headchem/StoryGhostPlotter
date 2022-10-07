using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class WesternsRailroads : IAppealTerm
{
    public string Id { get { return "WesternsRailroads"; } }
    public string Name { get { return "Railroads"; } }
    public string Description { get { return "Ribbons of steel opened up the West to new waves of settlers and opportunists."; } }
    public List<string> Genres { get { return new List<string> { "western" }; } }
    public List<string> Types { get { return new List<string> { "setting" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}