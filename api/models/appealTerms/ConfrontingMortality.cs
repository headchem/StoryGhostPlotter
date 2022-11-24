using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class ConfrontingMortality : IAppealTerm
{
    public string Id { get { return "ConfrontingMortality"; } }
    public string Name { get { return "Confronting mortality"; } }
    public string PromptLabel { get { return "coming to terms with mortality"; } }
    public string Description { get { return "These characters are faced with the inevitability of death."; } }
    public List<string> Genres { get { return GenresEnum.All; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.LifeChallenges }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}