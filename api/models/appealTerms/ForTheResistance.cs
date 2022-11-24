using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class ForTheResistance : IAppealTerm
{
    public string Id { get { return "ForTheResistance"; } }
    public string Name { get { return "For the resistance"; } }
    public string PromptLabel { get { return "fighting for a cause"; } }
    public string Description { get { return "These freedom fighters won't give up fighting for the cause they believe in."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Action, GenresEnum.Adventure, GenresEnum.Fantasy, GenresEnum.History, GenresEnum.ScienceFiction, GenresEnum.Thriller, GenresEnum.Urban, GenresEnum.War, GenresEnum.Western }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.PowerStructures }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}