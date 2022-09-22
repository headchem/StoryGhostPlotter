using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class QuestForMagicalItems : IAppealTerm
{
    public string Id { get { return "QuestForMagicalItems"; } }
    public string Name { get { return "Quest for magical items"; } }
    public string Description { get { return "The objects of power are scattered let the hunt begin!"; } }
    public List<string> Genres { get { return new List<string> { "fantasy" }; } }
    public List<string> Types { get { return new List<string> { "Plot" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}