using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class BeyondTheGrave : IAppealTerm
{
    public string Id { get { return "BeyondTheGrave"; } }
    public string Name { get { return "Beyond the grave"; } }
    public string Description { get { return "Crime victims investigate their own murders."; } }
    public List<string> Genres { get { return new List<string> { "mystery" }; } }
    public List<string> Types { get { return new List<string> { "Plot" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}