using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class BigPlan : IAppealTerm
{
    public string Id { get { return "BigPlan"; } }
    public string Name { get { return "Big Plan"; } }
    public string Description { get { return "A resourceful leader brainstorms and executes a complicated and risky plan - with huge potential payoffs."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Action, GenresEnum.Thriller, GenresEnum.Crime }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Situations, AppealTermsCategoryEnum.OccupationsAndEnterprise }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}