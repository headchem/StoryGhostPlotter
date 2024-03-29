using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class ReluctantAllies : IAppealTerm
{
    public string Id { get { return "ReluctantAllies"; } }
    public string Name { get { return "Reluctant allies"; } }
    public string PromptLabel { get { return "enemies who must join forces for a common cause"; } }
    public string Description { get { return "To survive, enemies must make common cause."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Action, GenresEnum.Adventure, GenresEnum.Comedy, GenresEnum.Drama, GenresEnum.History, GenresEnum.Sports, GenresEnum.Thriller, GenresEnum.War, GenresEnum.Western }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Situations, AppealTermsCategoryEnum.Relationships }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}