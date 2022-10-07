using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class HistoricalExplorationRenaissance : IAppealTerm
{
    public string Id { get { return "HistoricalExplorationRenaissance"; } }
    public string Name { get { return "Exploration Renaissance"; } }
    public string Description { get { return "Starting in the fifteenth and sixteenth centuries, varying from place to place, a great change took place in Western civilization as a new focus was put on learning and exploration."; } }
    public List<string> Genres { get { return new List<string> { "history" }; } }
    public List<string> Types { get { return new List<string> { "setting" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}