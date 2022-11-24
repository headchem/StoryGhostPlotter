using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class NewInTown : IAppealTerm
{
    public string Id { get { return "NewInTown"; } }
    public string Name { get { return "New in town"; } }
    public string PromptLabel { get { return "moving to a new town"; } }
    public string Description { get { return "Moving to a new town leads to new relationships."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Romance, GenresEnum.Drama }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Settings, AppealTermsCategoryEnum.Situations }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}