using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class HistoricalExoticLocales : IAppealTerm
{
    public string Id { get { return "HistoricalExoticLocales"; } }
    public string Name { get { return "Exotic Locales"; } }
    public string Description { get { return "Exploration resulted in awareness of and experiences in many new lands. Although set in the same time period as The Renaissance, the locales in this section are exotic from a Western perspective, which is the point of view generally taken by the authors."; } }
    public List<string> Genres { get { return new List<string> { "history" }; } }
    public List<string> Types { get { return new List<string> { "setting" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}