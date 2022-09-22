using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class ScumAndVillainy : IAppealTerm
{
    public string Id { get { return "ScumAndVillainy"; } }
    public string Name { get { return "Scum and villainy"; } }
    public string Description { get { return "Sometimes you have to root for the bad guy."; } }
    public List<string> Genres { get { return new List<string> { "fantasy", "adventure" }; } }
    public List<string> Types { get { return new List<string> { "Characters" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}