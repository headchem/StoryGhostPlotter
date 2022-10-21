using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class RoyalReads : IAppealTerm
{
    public string Id { get { return "RoyalReads"; } }
    public string Name { get { return "Royal reads"; } }
    public string Description { get { return "It's good to be the king... or is it? Reluctant Royals throughout history have wrestled with this question."; } }
    public List<string> Genres { get { return new List<string> { "drama", "history" }; } }
    public List<string> Categories { get { return new List<string> { "Historical" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}