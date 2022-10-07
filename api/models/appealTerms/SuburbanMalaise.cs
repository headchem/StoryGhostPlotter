using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class SuburbanMalaise : IAppealTerm
{
    public string Id { get { return "SuburbanMalaise"; } }
    public string Name { get { return "Suburban malaise"; } }
    public string Description { get { return "What went wrong in the quest for the American Dream?"; } }
    public List<string> Genres { get { return new List<string> { "action", "crime", "thriller", "urban" }; } }
    public List<string> Types { get { return new List<string> { "Setting" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}