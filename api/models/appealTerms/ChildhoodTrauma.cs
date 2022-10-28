using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class ChildhoodTrauma : IAppealTerm
{
    public string Id { get { return "ChildhoodTrauma"; } }
    public string Name { get { return "Childhood trauma"; } }
    public string Description { get { return "Innocence is lost through a confrontation with evil."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Horror, GenresEnum.Drama }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Characters, AppealTermsCategoryEnum.LifeChallenges }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}