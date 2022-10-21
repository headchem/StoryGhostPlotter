using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class StarringFamousFigures : IAppealTerm
{
    public string Id { get { return "StarringFamousFigures"; } }
    public string Name { get { return "Starring famous figures"; } }
    public string Description { get { return "Famous figures from history play leading roles."; } }
    public List<string> Genres { get { return new List<string> { "" }; } }
    public List<string> Categories { get { return new List<string> { "Characters" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}