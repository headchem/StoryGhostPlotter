using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class HighTechLowLife : IAppealTerm
{
    public string Id { get { return "HighTechLowLife"; } }
    public string Name { get { return "High-Tech, Low-Life"; } }
    public string Description { get { return "Also called Cyberpunk, these stories are set in the near future, focusing on low-life characters with access to advanced technology. Radical changes/breakdown of social order. Loners, freaks, hackers abound. Use of technology never intended by its creators."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.ScienceFiction, GenresEnum.Urban }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Settings, AppealTermsCategoryEnum.PowerStructures, AppealTermsCategoryEnum.ApocalypticAndDystopian }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}