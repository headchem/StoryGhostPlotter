using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class Steampunk : IAppealTerm
{
    public string Id { get { return "Steampunk"; } }
    public string Name { get { return "Steampunk"; } }
    public string Description { get { return "Combining Victorian and Western time frames."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Fantasy, GenresEnum.Western }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Settings }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}