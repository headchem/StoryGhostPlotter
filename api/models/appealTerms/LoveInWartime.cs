using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class LoveInWartime : IAppealTerm
{
    public string Id { get { return "LoveInWartime"; } }
    public string Name { get { return "Love in wartime"; } }
    public string PromptLabel { get { return "love during wartime"; } }
    public string Description { get { return "Couples in these stories feel the impact of battle on their relationship."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.History, GenresEnum.Romance, GenresEnum.Urban, GenresEnum.War }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Situations, AppealTermsCategoryEnum.Relationships, AppealTermsCategoryEnum.Settings }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}