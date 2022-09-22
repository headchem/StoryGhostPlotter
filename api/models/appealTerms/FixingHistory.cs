using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class FixingHistory : IAppealTerm
{
    public string Id { get { return "FixingHistory"; } }
    public string Name { get { return "Fixing history"; } }
    public string Description { get { return "Time travel to alter the past or save the future."; } }
    public List<string> Genres { get { return new List<string> { "science fiction", "action", "adventure" }; } }
    public List<string> Types { get { return new List<string> { "Space and Time", "Plot" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}