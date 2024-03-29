using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class GoingStraight : IAppealTerm
{
    public string Id { get { return "GoingStraight"; } }
    public string Name { get { return "Going straight"; } }
    public string PromptLabel { get { return "leaving criminal life"; } }
    public string Description { get { return "Leaving criminal street life for law-abiding straight life isn't easy."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Urban}; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.LifeChallenges, AppealTermsCategoryEnum.OccupationsAndEnterprise, AppealTermsCategoryEnum.PowerStructures }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}