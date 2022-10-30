using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class SleuthsInSchool : IAppealTerm
{
    public string Id { get { return "SleuthsInSchool"; } }
    public string Name { get { return "Sleuths in school"; } }
    public string Description { get { return "Kid-size crimes get sent to the principal's office."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Mystery }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Settings, AppealTermsCategoryEnum.OccupationsAndEnterprise }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}