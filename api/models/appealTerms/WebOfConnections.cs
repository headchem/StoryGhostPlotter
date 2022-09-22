using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class WebOfConnections : IAppealTerm
{
    public string Id { get { return "WebOfConnections"; } }
    public string Name { get { return "Web of connections"; } }
    public string Description { get { return "Inanimate objects are given a unique voice."; } }
    public List<string> Genres { get { return new List<string> { "adventure", "family" }; } }
    public List<string> Types { get { return new List<string> { "Narrative Devices" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}