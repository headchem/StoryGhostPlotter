using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class LoveInWartime : IAppealTerm
{
    public string Id { get { return "LoveInWartime"; } }
    public string Name { get { return "Love in wartime"; } }
    public string Description { get { return "Couples in these novels feel the impact of battle on their relationship."; } }
    public List<string> Genres { get { return new List<string> { "" }; } }
    public List<string> Types { get { return new List<string> { "Historical" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}