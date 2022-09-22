using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class TroubleAtHome : IAppealTerm
{
    public string Id { get { return "TroubleAtHome"; } }
    public string Name { get { return "Trouble at home"; } }
    public string Description { get { return "How are things at home? It can be a loaded question."; } }
    public List<string> Genres { get { return new List<string> { "drama", "urban" }; } }
    public List<string> Types { get { return new List<string> { "Family and Relationships" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}