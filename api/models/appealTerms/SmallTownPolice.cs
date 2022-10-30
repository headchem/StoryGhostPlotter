using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class SmallTownPolice : IAppealTerm
{
    public string Id { get { return "SmallTownPolice"; } }
    public string Name { get { return "Small town police"; } }
    public string Description { get { return "Small towns can have big crimes."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Mystery, GenresEnum.Crime }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Settings, AppealTermsCategoryEnum.PowerStructures }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}