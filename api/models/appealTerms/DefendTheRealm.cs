using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class DefendTheRealm : IAppealTerm
{
    public string Id { get { return "DefendTheRealm"; } }
    public string Name { get { return "Defend the realm"; } }
    public string Description { get { return "Call the banners and rally to the cause to defend the kingdom."; } }
    public List<string> Genres { get { return new List<string> { "fantasy" }; } }
    public List<string> Types { get { return new List<string> { "Plot" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}