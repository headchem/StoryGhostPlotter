using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class HardenedProfessional : IAppealTerm
{
    public string Id { get { return "HardenedProfessional"; } }
    public string Name { get { return "HardenedProfessional"; } }
    public string PromptLabel { get { return "a hardened and experienced criminal investigator"; } }
    public string Description { get { return "They've seen it all - but the crime this time is different and more shocking than usual."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Mystery, GenresEnum.Crime }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Characters, AppealTermsCategoryEnum.OccupationsAndEnterprise }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}