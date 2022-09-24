using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class RichDetective : IAppealTerm
{
    public string Id { get { return "RichDetective"; } }
    public string Name { get { return "Rich Detective"; } }
    public string Description { get { return "These detectives come from upper society and use their free time, wealth and privileged connections to solve crime."; } }
    public List<string> Genres { get { return new List<string> { "mystery" }; } }
    public List<string> Types { get { return new List<string> { "Characters" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}