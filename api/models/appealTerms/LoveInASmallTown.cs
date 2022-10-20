using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class LoveInASmallTown : IAppealTerm
{
    public string Id { get { return "LoveInASmallTown"; } }
    public string Name { get { return "Love in a small town"; } }
    public string Description { get { return "Fall in love where everyone knows your name, but it's hard to keep secrets."; } }
    public List<string> Genres { get { return new List<string> { "romance" }; } }
    public List<string> Types { get { return new List<string> { "Setting" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}