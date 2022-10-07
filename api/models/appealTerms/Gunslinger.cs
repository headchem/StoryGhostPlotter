using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class Gunslinger : IAppealTerm
{
    public string Id { get { return "Gunslinger"; } }
    public string Name { get { return "Gunslinger"; } }
    public string Description { get { return "What's the point of being the fastest gun in town if you don't use it?"; } }
    public List<string> Genres { get { return new List<string> { "western" }; } }
    public List<string> Types { get { return new List<string> { "Characters" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}