using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class OnTheDownLow : IAppealTerm
{
    public string Id { get { return "OnTheDownLow"; } }
    public string Name { get { return "On the down low"; } }
    public string Description { get { return "Characters secretly pursue same-sex relationships."; } }
    public List<string> Genres { get { return new List<string> { "urban" }; } }
    public List<string> Categories { get { return new List<string> { "Plot" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}