using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class EatDrinkAndBeMerry : IAppealTerm
{
    public string Id { get { return "EatDrinkAndBeMerry"; } }
    public string Name { get { return "Eat drink and be merry"; } }
    public string Description { get { return "These stories are immersed in culinary culture."; } }
    public List<string> Genres { get { return new List<string> { "" }; } }
    public List<string> Types { get { return new List<string> { "Aficionado" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}