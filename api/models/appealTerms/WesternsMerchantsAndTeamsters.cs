using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class WesternsMerchantsAndTeamsters : IAppealTerm
{
    public string Id { get { return "WesternsMerchantsAndTeamsters"; } }
    public string Name { get { return "Merchants and Teamsters"; } }
    public string Description { get { return ""; } }
    public List<string> Genres { get { return new List<string> { "western" }; } }
    public List<string> Types { get { return new List<string> { "characters" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}