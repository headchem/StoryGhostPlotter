using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class ArmchairDetection : IAppealTerm
{
    public string Id { get { return "ArmchairDetection"; } }
    public string Name { get { return "Armchair Detection"; } }
    public string Description { get { return "Solving the case from afar with pure intellect."; } }
    public List<string> Genres { get { return new List<string> { "mystery" }; } }
    public List<string> Types { get { return new List<string> { "Setting" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}