using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class WesternsMerchantsAndTeamsters : IAppealTerm
{
    public string Id { get { return "WesternsMerchantsAndTeamsters"; } }
    public string Name { get { return "Merchants and Teamsters"; } }
    public string Description { get { return "For the West to be opened up, goods and supplies had to be brought in. The enterprising individuals who journeyed West to make a profit were generally a colorful lot, and their broad experience with various individuals in the West offers readers a unique perspective on the times."; } }
    public List<string> Genres { get { return new List<string> { "western" }; } }
    public List<string> Types { get { return new List<string> { "characters" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}