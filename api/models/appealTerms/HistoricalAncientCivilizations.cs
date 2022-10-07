using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class HistoricalAncientCivilizations : IAppealTerm
{
    public string Id { get { return "HistoricalAncientCivilizations"; } }
    public string Name { get { return "Ancient Civilizations"; } }
    public string Description { get { return "Tales set in ancient civilizations provide a sense of lost wonders and settings that seem more exotic than those in eras with well-documented history."; } }
    public List<string> Genres { get { return new List<string> { "history" }; } }
    public List<string> Types { get { return new List<string> { "setting" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}