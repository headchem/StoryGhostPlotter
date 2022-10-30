using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class ScumAndVillainy : IAppealTerm
{
    public string Id { get { return "ScumAndVillainy"; } }
    public string Name { get { return "Scum and villainy"; } }
    public string Description { get { return "Sometimes you have to root for the bad guy."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Action, GenresEnum.Adventure, GenresEnum.Comedy, GenresEnum.Crime, GenresEnum.Drama, GenresEnum.Fantasy, GenresEnum.History, GenresEnum.Music, GenresEnum.Mystery, GenresEnum.ScienceFiction, GenresEnum.Sports, GenresEnum.Thriller, GenresEnum.Urban, GenresEnum.Western }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Characters }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}