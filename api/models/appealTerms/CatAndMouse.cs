using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class CatAndMouse : IAppealTerm
{
    public string Id { get { return "CatAndMouse"; } }
    public string Name { get { return "Cat And Mouse"; } }
    public string Description { get { return "Both the hero and villain are one step ahead and behind of each other."; } }
    public List<string> Genres { get { return new List<string> { "thriller" }; } }
    public List<string> Types { get { return new List<string> { "Characters" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}