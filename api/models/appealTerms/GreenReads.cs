using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class GreenReads : IAppealTerm
{
    public string Id { get { return "GreenReads"; } }
    public string Name { get { return "Green reads"; } }
    public string PromptLabel { get { return "humanity's relationship with nature"; } }
    public string Description { get { return "Explore our relationship with the natural world."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Adventure, GenresEnum.Family, GenresEnum.History, GenresEnum.Western }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Settings, AppealTermsCategoryEnum.Concepts }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}