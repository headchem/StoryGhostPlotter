using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class SuperFamilies : IAppealTerm
{
    public string Id { get { return "SuperFamilies"; } }
    public string Name { get { return "Super families"; } }
    public string PromptLabel { get { return "a family with super powers"; } }
    public string Description { get { return "Families that fight together, stay together."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Action, GenresEnum.Adventure, GenresEnum.Fantasy, GenresEnum.Comedy, GenresEnum.Drama, GenresEnum.Thriller, GenresEnum.Urban, GenresEnum.War, GenresEnum.Western }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Characters }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}