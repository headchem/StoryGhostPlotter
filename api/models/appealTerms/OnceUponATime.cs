using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class OnceUponATime : IAppealTerm
{
    public string Id { get { return "OnceUponATime"; } }
    public string Name { get { return "Once upon a time"; } }
    public string Description { get { return "These fairy tales end in happily-ever-after."; } }
    public List<string> Genres { get { return new List<string> { "" }; } }
    public List<string> Types { get { return new List<string> { "" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}