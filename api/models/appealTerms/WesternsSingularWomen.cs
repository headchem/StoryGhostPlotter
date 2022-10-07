using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class WesternsSingularWomen : IAppealTerm
{
    public string Id { get { return "WesternsSingularWomen"; } }
    public string Name { get { return "Singular Women"; } }
    public string Description { get { return "In early Westerns, women played lesser roles than horses and were often depicted stereotypically or in unflattering terms. Fortunately this has changed in recent years, with strong, independent women playing prominent roles."; } }
    public List<string> Genres { get { return new List<string> { "western" }; } }
    public List<string> Types { get { return new List<string> { "characters" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}