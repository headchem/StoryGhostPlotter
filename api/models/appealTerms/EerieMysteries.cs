using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class EerieMysteries : IAppealTerm
{
    public string Id { get { return "EerieMysteries"; } }
    public string Name { get { return "Eerie mysteries"; } }
    public string Description { get { return "These capers seem supernatural until the mystery is revealed to be grounded in reality."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Mystery }; } }
    public List<string> Categories { get { return new List<string> { "Plot" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}