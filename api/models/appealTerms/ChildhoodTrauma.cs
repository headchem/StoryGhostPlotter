using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class ChildhoodTrauma : IAppealTerm
{
    public string Id { get { return "ChildhoodTrauma"; } }
    public string Name { get { return "Childhood trauma"; } }
    public string Description { get { return "Innocence is lost through a confrontation with evil."; } }
    public List<string> Genres { get { return new List<string> { "horror" }; } }
    public List<string> Types { get { return new List<string> { "Characters" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}