using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class ConfrontingMortality : IAppealTerm
{
    public string Id { get { return "ConfrontingMortality"; } }
    public string Name { get { return "Confronting mortality"; } }
    public string Description { get { return "These characters are faced with the inevitability of death."; } }
    public List<string> Genres { get { return new List<string> { "drama", "romance", "thriller", "war" }; } }
    public List<string> Categories { get { return new List<string> { "Life's Challenges" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}