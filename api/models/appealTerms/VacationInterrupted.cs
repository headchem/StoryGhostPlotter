using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class VacationInterrupted : IAppealTerm
{
    public string Id { get { return "VacationInterrupted"; } }
    public string Name { get { return "Vacation interrupted"; } }
    public string PromptLabel { get { return "a detective's vacation being interrupted by a crime"; } }
    public string Description { get { return "A day at the beach turns dangerous for these off-duty sleuths."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Mystery }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Settings, AppealTermsCategoryEnum.OccupationsAndEnterprise }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}