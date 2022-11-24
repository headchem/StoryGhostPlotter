using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class EatDrinkAndBeMerry : IAppealTerm
{
    public string Id { get { return "EatDrinkAndBeMerry"; } }
    public string Name { get { return "Eat drink and be merry"; } }
    public string PromptLabel { get { return "culinary culture"; } }
    public string Description { get { return "These stories are immersed in culinary culture."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Adventure, GenresEnum.Comedy, GenresEnum.Family, GenresEnum.History, GenresEnum.Mystery, GenresEnum.Romance }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Concepts, AppealTermsCategoryEnum.OccupationsAndEnterprise }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}