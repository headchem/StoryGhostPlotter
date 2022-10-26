using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class ComedyOfManners : IAppealTerm
{
    public string Id { get { return "ComedyOfManners"; } }
    public string Name { get { return "Comedy of manners"; } }
    public string Description { get { return "Poking fun at social standards."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Comedy }; } }
    public List<string> Categories { get { return new List<string> { "Concepts and Characters" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}