using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class HistoricalAmericas : IAppealTerm
{
    public string Id { get { return "HistoricalAmericas"; } }
    public string Name { get { return "Americas"; } }
    public string Description { get { return "New frontiers and unexplored lands offer a broad canvas for fiction. Frontiers, whether in Australia, the American West, or other locales, provide fertile ground for the clash between \"civilization\" and the wilderness. The lure of a place far from corrupt cities, crowds, jobs, and schools offers freedom, danger, and excitement. Like many sagas, many of these novels feature families or individuals moving to a new land to seek their fortunes and establish themselves."; } }
    public List<string> Genres { get { return new List<string> { "history" }; } }
    public List<string> Types { get { return new List<string> { "setting" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}