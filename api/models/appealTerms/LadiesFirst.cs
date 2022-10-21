using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class LadiesFirst : IAppealTerm
{
    public string Id { get { return "LadiesFirst"; } }
    public string Name { get { return "Ladies first"; } }
    public string Description { get { return "These women do what it takes to get paid, get revenge, or get theirs."; } }
    public List<string> Genres { get { return new List<string> { "urban" }; } }
    public List<string> Categories { get { return new List<string> { "Characters" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}