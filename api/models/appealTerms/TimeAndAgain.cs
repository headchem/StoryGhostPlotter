using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class TimeAndAgain : IAppealTerm
{
    public string Id { get { return "TimeAndAgain"; } }
    public string Name { get { return "Time and again"; } }
    public string Description { get { return "If you'd made a different choice, what might have been?"; } }
    public List<string> Genres { get { return new List<string> { "action", "romance", "thriller" }; } }
    public List<string> Types { get { return new List<string> { "Narrative Devices" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}