using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class WesternsSingularWomen : IAppealTerm
{
    public string Id { get { return "WesternsSingularWomen"; } }
    public string Name { get { return "Singular Women"; } }
    //public string Description { get { return "In early Westerns, women played lesser roles than horses and were often depicted stereotypically or in unflattering terms. Fortunately this has changed in recent years, with strong, independent women playing prominent roles."; } }
    public string Description { get { return "The West was especially harsh for women. These stories involve females who survive and thrive with grit."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Western }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Characters }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}