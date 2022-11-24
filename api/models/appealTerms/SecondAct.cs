using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class SecondAct : IAppealTerm
{
    public string Id { get { return "SecondAct"; } }
    public string Name { get { return "Second act"; } }
    public string PromptLabel { get { return "characters approaching old age"; } }
    public string Description { get { return "These older characters show that life's second half has stories worth telling, too."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Action, GenresEnum.Adventure, GenresEnum.Comedy, GenresEnum.Drama, GenresEnum.Fantasy, GenresEnum.Family, GenresEnum.History, GenresEnum.Music, GenresEnum.Mystery, GenresEnum.ScienceFiction, GenresEnum.Sports, GenresEnum.Thriller, GenresEnum.Urban, GenresEnum.Western }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Characters, AppealTermsCategoryEnum.Concepts }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}