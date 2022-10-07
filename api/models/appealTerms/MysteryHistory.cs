using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class MysteryHistory : IAppealTerm
{
    public string Id { get { return "MysteryHistory"; } }
    public string Name { get { return "Mystery History"; } }
    public string Description { get { return "Solving old crimes from the past using new methods and discoveries."; } }
    public List<string> Genres { get { return new List<string> { "mystery" }; } }
    public List<string> Types { get { return new List<string> { "Setting" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}