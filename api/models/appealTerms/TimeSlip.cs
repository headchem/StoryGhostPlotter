using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class TimeSlip : IAppealTerm
{
    public string Id { get { return "TimeSlip"; } }
    public string Name { get { return "Time slip"; } }
    public string Description { get { return "Characters emerge somewhere else — past or future."; } }
    public List<string> Genres { get { return new List<string> { "" }; } }
    public List<string> Types { get { return new List<string> { "" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}