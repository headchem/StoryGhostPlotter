using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class BandOfSurvivors : IAppealTerm
{
    public string Id { get { return "BandOfSurvivors"; } }
    public string Name { get { return "Band of survivors"; } }
    public string Description { get { return "Teamwork means survival."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Action, GenresEnum.Adventure, GenresEnum.Fantasy, GenresEnum.Horror, GenresEnum.ScienceFiction, GenresEnum.Thriller, GenresEnum.Urban, GenresEnum.War, GenresEnum.Western }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.ApocalypticAndDystopian, AppealTermsCategoryEnum.Characters }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}