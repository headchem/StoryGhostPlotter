using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class WesternsWagonsWestAndEarlySettlement : IAppealTerm
{
    public string Id { get { return "WesternsWagonsWestAndEarlySettlement"; } }
    public string Name { get { return "Wagons West and EarlySettlement"; } }
    public string PromptLabel { get { return "early settlers journeying into the American West"; } }
    //public string Description { get { return "The westward journey of the nineteenth century, fraught with perils and hazards, placed ordinary people in extraordinary circumstances that tested their grit and endurance. The long and arduous journey from the East was often undertaken by family groups, who faced disease, disaster, and disaffection."; } }
    public string Description { get { return "The westward journey was fraught with perils and hazards. The long and arduous journey from the East challenged settlers with disease, disaster, and disaffection."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Western }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Settings, AppealTermsCategoryEnum.OccupationsAndEnterprise }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}