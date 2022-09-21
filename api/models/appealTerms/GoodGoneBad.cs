using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class GoodGoneBad : IAppealTerm
{
    public string Id { get { return "GoodGoneBad"; } }
    public string Name { get { return "Good gone bad"; } }
    public string Description { get { return "Life on the streets can be irresistible."; } }
    public List<string> Genres { get { return new List<string> { "" }; } }
    public List<string> Types { get { return new List<string> { "" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}