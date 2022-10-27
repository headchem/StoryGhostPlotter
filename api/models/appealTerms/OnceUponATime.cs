using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class OnceUponATime : IAppealTerm
{
    public string Id { get { return "OnceUponATime"; } }
    public string Name { get { return "Once upon a time romance"; } }
    public string Description { get { return "These fairy tales end in happily-ever-after."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Romance, GenresEnum.Fantasy }; } }
    public List<string> Categories { get { return new List<string> { "Plot" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}