using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class CorporateGames : IAppealTerm
{
    public string Id { get { return "CorporateGames"; } }
    public string Name { get { return "Corporate Games"; } }
    public string Description { get { return "The legal and finance departments have more than money at stake, with dramatic consequences."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Crime, GenresEnum.Drama, GenresEnum.Thriller }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Concepts, AppealTermsCategoryEnum.PowerStructures }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}