using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class ForRicherForPoorer : IAppealTerm
{
    public string Id { get { return "ForRicherForPoorer"; } }
    public string Name { get { return "For richer for poorer"; } }
    public string PromptLabel { get { return "romance amongst in upper class"; } }
    public string Description { get { return "Romance amongst society's wealthy upper crust."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Romance }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Characters, AppealTermsCategoryEnum.Settings }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}