using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class LifeOnTheInside : IAppealTerm
{
    public string Id { get { return "LifeOnTheInside"; } }
    public string Name { get { return "Life on the inside"; } }
    public string PromptLabel { get { return "prison life"; } }
    public string Description { get { return "Raw views of prison life."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Urban }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Settings, AppealTermsCategoryEnum.PowerStructures }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}