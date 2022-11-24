using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class LifeInSmallTowns : IAppealTerm
{
    public string Id { get { return "LifeInSmallTowns"; } }
    public string Name { get { return "Life in small towns"; } }
    public string PromptLabel { get { return "life in small towns"; } }
    public string Description { get { return "Everyone knows everyone else in these communities."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Comedy, GenresEnum.Drama, GenresEnum.Mystery, GenresEnum.Romance }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Settings }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}