using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class HistoricalMiddleAges : IAppealTerm
{
    public string Id { get { return "HistoricalMiddleAges"; } }
    public string Name { get { return "The Middle Ages"; } }
    public string PromptLabel { get { return "the Middle Ages"; } }
    public string Description { get { return "Very roughly, the years from A.D. 500 to 1500 may be called the Middle Ages. Knights, castles, and fiefdoms abound."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.History }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Settings }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}