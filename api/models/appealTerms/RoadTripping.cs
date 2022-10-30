using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class RoadTripping : IAppealTerm
{
    public string Id { get { return "RoadTripping"; } }
    public string Name { get { return "Road tripping"; } }
    public string Description { get { return "Long-distance travel, pit stops, getting lost... and self-discovery?"; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Adventure, GenresEnum.Comedy, GenresEnum.Family }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Concepts, AppealTermsCategoryEnum.Characters }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}