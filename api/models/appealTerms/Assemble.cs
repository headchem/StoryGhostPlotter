using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class Assemble : IAppealTerm
{
    public string Id { get { return "Assemble"; } }
    public string Name { get { return "Assemble"; } }
    public string Description { get { return "TEAM Together Everyone Achieves More."; } }
    public List<string> Genres { get { return new List<string> { "action", "adventure" }; } }
    public List<string> Types { get { return new List<string> { "Plot" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}