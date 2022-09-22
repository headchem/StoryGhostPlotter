using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class MusicalReads : IAppealTerm
{
    public string Id { get { return "MusicalReads"; } }
    public string Name { get { return "Musical reads"; } }
    public string Description { get { return "Featuring performances from musicians, composers, and music lovers."; } }
    public List<string> Genres { get { return new List<string> { "history", "music" }; } }
    public List<string> Types { get { return new List<string> { "Aficionado" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}