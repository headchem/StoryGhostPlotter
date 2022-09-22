using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class RightfulHeir : IAppealTerm
{
    public string Id { get { return "RightfulHeir"; } }
    public string Name { get { return "Rightful heir"; } }
    public string Description { get { return "Usurpers and traitors stand in the way of the throne."; } }
    public List<string> Genres { get { return new List<string> { "fantasy" }; } }
    public List<string> Types { get { return new List<string> { "Characters" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}