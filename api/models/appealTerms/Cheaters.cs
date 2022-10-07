using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class Cheaters : IAppealTerm
{
    public string Id { get { return "Cheaters"; } }
    public string Name { get { return "Cheaters"; } }
    public string Description { get { return "Outrageous acts of infidelity."; } }
    public List<string> Genres { get { return new List<string> { "urban" }; } }
    public List<string> Types { get { return new List<string> { "Characters" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}