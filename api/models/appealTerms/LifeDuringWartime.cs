using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class LifeDuringWartime : IAppealTerm
{
    public string Id { get { return "LifeDuringWartime"; } }
    public string Name { get { return "Life during wartime"; } }
    public string Description { get { return "War changes life for everybody."; } }
    public List<string> Genres { get { return new List<string> { "action", "drama", "history", "romance", "thriller", "urban", "war" }; } }
    public List<string> Categories { get { return new List<string> { "Concepts and Characters" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}