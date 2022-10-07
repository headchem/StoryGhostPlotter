using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class HistoricalMiddleAges : IAppealTerm
{
    public string Id { get { return "HistoricalMiddleAges"; } }
    public string Name { get { return "Middle Ages"; } }
    public string Description { get { return "Very roughly, the years from A.D. 500 to 1500 may be called the Middle Ages."; } }
    public List<string> Genres { get { return new List<string> { "history" }; } }
    public List<string> Types { get { return new List<string> { "setting" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}