using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class ShadowOrganizations : IAppealTerm
{
    public string Id { get { return "ShadowOrganizations"; } }
    public string Name { get { return "Shadow organizations"; } }
    public string PromptLabel { get { return "secret organizations that wield power from the shadows"; } }
    public string Description { get { return "Who's in control? These secret societies wield power from the shadows."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Crime, GenresEnum.Fantasy, GenresEnum.History, GenresEnum.ScienceFiction, GenresEnum.Thriller }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Concepts, AppealTermsCategoryEnum.Secrets }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}