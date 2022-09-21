using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class ReluctantAllies : IAppealTerm
{
    public string Id { get { return "ReluctantAllies"; } }
    public string Name { get { return "Reluctant allies"; } }
    public string Description { get { return "To survive, enemies must make common cause."; } }
    public List<string> Genres { get { return new List<string> { "" }; } }
    public List<string> Types { get { return new List<string> { "" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}