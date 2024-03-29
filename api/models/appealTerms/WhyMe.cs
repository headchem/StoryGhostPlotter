using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class WhyMe : IAppealTerm
{
    public string Id { get { return "WhyMe"; } }
    public string Name { get { return "Why Me?"; } }
    public string PromptLabel { get { return "an ordinary person caught in the schemes of a terrifying villain"; } }
    public string Description { get { return "An ordinary protagonist gets accidentally or reluctantly caught up in the crosshairs of a terrifying and more powerful villain."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Action, GenresEnum.Thriller, GenresEnum.Crime, GenresEnum.Urban }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Characters, AppealTermsCategoryEnum.PowerStructures, AppealTermsCategoryEnum.Situations }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}