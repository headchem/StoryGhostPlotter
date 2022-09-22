using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class RookieOnTheBeat : IAppealTerm
{
    public string Id { get { return "RookieOnTheBeat"; } }
    public string Name { get { return "Rookie on the beat"; } }
    public string Description { get { return "Newbies must tackle crime as well as skeptical coworkers."; } }
    public List<string> Genres { get { return new List<string> { "mystery" }; } }
    public List<string> Types { get { return new List<string> { "Characters" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}