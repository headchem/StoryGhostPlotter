using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class TimeAndAgain : IAppealTerm
{
    public string Id { get { return "TimeAndAgain"; } }
    public string Name { get { return "Time and again"; } }
    public string Description { get { return "If you'd made a different choice, what might have been? How one small change can have drastic impacts on the sequences of events that follow."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.ScienceFiction }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.NarrativeDevices, AppealTermsCategoryEnum.SpaceAndTime, AppealTermsCategoryEnum.Concepts }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}