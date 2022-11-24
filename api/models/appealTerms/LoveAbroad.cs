using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class LoveAbroad : IAppealTerm
{
    public string Id { get { return "LoveAbroad"; } }
    public string Name { get { return "Love abroad"; } }
    public string PromptLabel { get { return "falling in love while traveling abroad"; } }
    public string Description { get { return "A travel adventure leads to love, but these characters have to return home eventually, right?"; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Romance }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Settings, AppealTermsCategoryEnum.Relationships, AppealTermsCategoryEnum.Characters }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}