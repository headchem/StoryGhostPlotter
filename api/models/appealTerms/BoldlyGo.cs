using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class BoldlyGo : IAppealTerm
{
    public string Id { get { return "BoldlyGo"; } }
    public string Name { get { return "Boldly go"; } }
    public string PromptLabel { get { return "exploring the cosmos"; } }
    public string Description { get { return "Humans explore the cosmos."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.ScienceFiction }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Settings, AppealTermsCategoryEnum.SpaceAndTime }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}