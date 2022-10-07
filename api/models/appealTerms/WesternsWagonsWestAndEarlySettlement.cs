using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class WesternsWagonsWestAndEarlySettlement : IAppealTerm
{
    public string Id { get { return "WesternsWagonsWestAndEarlySettlement"; } }
    public string Name { get { return "Wagons West and EarlySettlement"; } }
    public string Description { get { return "The westward journey of the nineteenth century, fraught with perils and hazards, placed ordinary people in extraordinary circumstances that tested their grit and endurance. The long and arduous journey from the East was often undertaken by family groups, who faced disease, disaster, and disaffection."; } }
    public List<string> Genres { get { return new List<string> { "western" }; } }
    public List<string> Types { get { return new List<string> { "setting" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}