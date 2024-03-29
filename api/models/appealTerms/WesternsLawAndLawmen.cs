using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class WesternsLawAndLawmen : IAppealTerm
{
    public string Id { get { return "WesternsLawAndLawmen"; } }
    public string Name { get { return "Law and Lawmen"; } }
    public string PromptLabel { get { return "sheriffs and the law in the Wild West"; } }
    public string Description { get { return "The frontier was a haven for the lawless, so tales of those who oppose them, trying to impose order on the chaos, take on a great significance."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Western }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Characters, AppealTermsCategoryEnum.PowerStructures, AppealTermsCategoryEnum.OccupationsAndEnterprise }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}