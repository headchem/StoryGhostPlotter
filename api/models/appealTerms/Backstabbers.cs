using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class Backstabbers : IAppealTerm
{
    public string Id { get { return "Backstabbers"; } }
    public string Name { get { return "Backstabbers"; } }
    public string Description { get { return "You just can't trust some people... These stories involve betrayal."; } }
    public List<string> Genres { get { return new List<string> { "urban" }; } }
    public List<string> Types { get { return new List<string> { "Characters" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}