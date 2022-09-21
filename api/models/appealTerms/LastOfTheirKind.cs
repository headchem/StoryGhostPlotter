using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class LastOfTheirKind : IAppealTerm
{
    public string Id { get { return "LastOfTheirKind"; } }
    public string Name { get { return "Last of their kind"; } }
    public string Description { get { return "They are all that remain of their people, or so they think."; } }
    public List<string> Genres { get { return new List<string> { "" }; } }
    public List<string> Types { get { return new List<string> { "" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}