using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class RookieOnTheBeat : IAppealTerm
{
    public string Id { get { return "RookieOnTheBeat"; } }
    public string Name { get { return "Rookie on the beat"; } }
    public string Description { get { return "Newbies must tackle crime and prove themselves to skeptical coworkers."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Crime, GenresEnum.Mystery }; } }
    public List<string> Categories { get { return new List<string> { "Characters" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}