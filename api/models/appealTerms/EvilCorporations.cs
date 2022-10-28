using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class EvilCorporations : IAppealTerm
{
    public string Id { get { return "EvilCorporations"; } }
    public string Name { get { return "Evil corporations"; } }
    public string Description { get { return "These companies care more about profits than ethics."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Action, GenresEnum.Crime, GenresEnum.Drama, GenresEnum.ScienceFiction, GenresEnum.Thriller, GenresEnum.Urban, GenresEnum.Western }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.ApocalypticAndDystopian, AppealTermsCategoryEnum.PowerStructures }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}