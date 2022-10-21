using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class WesternsMountainMen : IAppealTerm
{
    public string Id { get { return "WesternsMountainMen"; } }
    public string Name { get { return "Mountain Men"; } }
    public string Description { get { return "The earliest non-native people to travel the West were the mountain men and trappers, who often took on Indian ways."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Western }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Characters }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}