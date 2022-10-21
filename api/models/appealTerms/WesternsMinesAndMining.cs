using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class WesternsMinesAndMining : IAppealTerm
{
    public string Id { get { return "WesternsMinesAndMining"; } }
    public string Name { get { return "Mines and Mining"; } }
    public string Description { get { return "The lure of gold and silver brought many unlikely individuals together and brought out the best and the worst in them. The legends of lost mines and mother lodes drew many individuals to seek their fortunes."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Western }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.OccupationsAndEnterprise, AppealTermsCategoryEnum.Settings }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}