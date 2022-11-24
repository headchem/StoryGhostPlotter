using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class JustPolitics : IAppealTerm
{
    public string Id { get { return "JustPolitics"; } }
    public string Name { get { return "Just Politics"; } }
    public string PromptLabel { get { return "the pursuit of power in politics"; } }
    public string Description { get { return "The pursuit of power gets ugly as influential people jockey for control over the masses."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Thriller, GenresEnum.History }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Settings, AppealTermsCategoryEnum.PowerStructures }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}