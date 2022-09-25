using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class ScienceGoneTooFar : IAppealTerm
{
    public string Id { get { return "ScienceGoneTooFar"; } }
    public string Name { get { return "Science Gone Too Far"; } }
    public string Description { get { return "Science and technology pushed far beyond ethical boundaries, and we get exactly what we deserve."; } }
    public List<string> Genres { get { return new List<string> { "horror", "science fiction" }; } }
    public List<string> Types { get { return new List<string> { "Setting" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}