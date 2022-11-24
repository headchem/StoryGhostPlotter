using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class FamilyBusiness : IAppealTerm
{
    public string Id { get { return "FamilyBusiness"; } }
    public string Name { get { return "Family business"; } }
    public string PromptLabel { get { return "being part of a criminal family"; } }
    public string Description { get { return "When you're born into the criminal life, blood is thicker than water."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Crime, GenresEnum.Mystery, GenresEnum.Urban }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Characters, AppealTermsCategoryEnum.OccupationsAndEnterprise, AppealTermsCategoryEnum.PowerStructures }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}