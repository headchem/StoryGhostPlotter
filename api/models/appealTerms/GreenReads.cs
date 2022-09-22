using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class GreenReads : IAppealTerm
{
    public string Id { get { return "GreenReads"; } }
    public string Name { get { return "Green reads"; } }
    public string Description { get { return "Explore our relationship with the natural world."; } }
    public List<string> Genres { get { return new List<string> { "adventure", "family", "history", "western" }; } }
    public List<string> Types { get { return new List<string> { "Concepts and Characters" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}