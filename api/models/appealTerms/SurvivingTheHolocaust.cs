using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class SurvivingTheHolocaust : IAppealTerm
{
    public string Id { get { return "SurvivingTheHolocaust"; } }
    public string Name { get { return "Surviving the Holocaust"; } }
    public string Description { get { return "Read about Jewish characters and other targeted groups as they try to survive during the Nazi regime."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.History, GenresEnum.War }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.LifeChallenges, AppealTermsCategoryEnum.Settings }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}