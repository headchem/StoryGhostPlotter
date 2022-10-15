using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class OffLimitsLove : IAppealTerm
{
    public string Id { get { return "OffLimitsLove"; } }
    public string Name { get { return "Off Limits Love"; } }
    public string Description { get { return "Off limits… but so tempting."; } }
    public List<string> Genres { get { return new List<string> { "romance" }; } }
    public List<string> Types { get { return new List<string> { "Characters" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}