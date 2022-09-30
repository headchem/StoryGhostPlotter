using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class WomenOfSteel : IAppealTerm
{
    public string Id { get { return "WomenOfSteel"; } }
    public string Name { get { return "Women of steel"; } }
    public string Description { get { return "These damsels are in no way distressed, leaping at the chance for quest or battle."; } }
    public List<string> Genres { get { return new List<string> { "science fiction", "fantasy", "action", "adventure" }; } }
    public List<string> Types { get { return new List<string> { "Concepts and Characters" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}