using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class GoodGoneBad : IAppealTerm
{
    public string Id { get { return "GoodGoneBad"; } }
    public string Name { get { return "Good gone bad"; } }
    public string PromptLabel { get { return "the allure of criminal life"; } }
    public string Description { get { return "These characters struggle to stay out of trouble as the criminal life on the streets can be irresistible."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Urban, GenresEnum.Thriller, GenresEnum.Action, GenresEnum.Crime }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.PowerStructures, AppealTermsCategoryEnum.OccupationsAndEnterprise, AppealTermsCategoryEnum.LifeChallenges }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}