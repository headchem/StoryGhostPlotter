using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class SurvivingTheHolocaust : IAppealTerm
{
    public string Id { get { return "SurvivingTheHolocaust"; } }
    public string Name { get { return "Surviving the Holocaust"; } }
    public string Description { get { return "Read about Jewish characters and other targeted groups as they try to survive during the Nazi regime."; } }
    public List<string> Genres { get { return new List<string> { "action", "history", "thriller", "urban", "war" }; } }
    public List<string> Types { get { return new List<string> { "Historical" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}