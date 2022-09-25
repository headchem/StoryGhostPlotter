using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class CorporateGames : IAppealTerm
{
    public string Id { get { return "CorporateGames"; } }
    public string Name { get { return "Corporate Games"; } }
    public string Description { get { return "The legal and finance departments have more than money at stake."; } }
    public List<string> Genres { get { return new List<string> { "thriller" }; } }
    public List<string> Types { get { return new List<string> { "Plot" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}