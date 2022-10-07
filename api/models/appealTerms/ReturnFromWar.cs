using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class ReturnFromWar : IAppealTerm
{
    public string Id { get { return "ReturnFromWar"; } }
    public string Name { get { return "Return from war"; } }
    public string Description { get { return "Civilian life after war can be haunted by trauma."; } }
    public List<string> Genres { get { return new List<string> { "drama", "history", "urban", "war" }; } }
    public List<string> Types { get { return new List<string> { "Concepts and Characters" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}