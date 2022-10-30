using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class SpaceOpera : IAppealTerm
{
    public string Id { get { return "SpaceOpera"; } }
    public string Name { get { return "Space Opera"; } }
    public string Description { get { return "Stories on a grand scale. Include a bit of everything: romance, action, adventure. Sweeping, epic tales. War and politics play important roles."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.ScienceFiction }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.SpaceAndTime, AppealTermsCategoryEnum.Settings, AppealTermsCategoryEnum.PowerStructures }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}