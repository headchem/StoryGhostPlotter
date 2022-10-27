using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class UnderdogAthletes : IAppealTerm
{
    public string Id { get { return "UnderdogAthletes"; } }
    public string Name { get { return "Underdog athletes"; } }
    public string Description { get { return "These teams consist of lovable losers."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Family, GenresEnum.Sports }; } }
    public List<string> Categories { get { return new List<string> { "Concepts and Characters" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}