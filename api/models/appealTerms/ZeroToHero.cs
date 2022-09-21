using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class ZeroToHero : IAppealTerm
{
    public string Id { get { return "ZeroToHero"; } }
    public string Name { get { return "Zero to hero"; } }
    public string Description { get { return "You’ve got to start somewhere. These characters achieve greatness from humble beginnings."; } }
    public List<string> Genres { get { return new List<string> { "" }; } }
    public List<string> Types { get { return new List<string> { "" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}