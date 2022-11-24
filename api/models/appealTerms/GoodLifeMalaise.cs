using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class GoodLifeMalaise : IAppealTerm
{
    public string Id { get { return "GoodLifeMalaise"; } }
    public string Name { get { return "Good life malaise"; } }
    public string PromptLabel { get { return "feeling malaise despite having a comfortable life"; } }
    public string Description { get { return "What went wrong in the quest for the good life?"; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Drama, GenresEnum.Urban }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Settings }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}