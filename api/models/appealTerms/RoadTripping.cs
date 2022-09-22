using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class RoadTripping : IAppealTerm
{
    public string Id { get { return "RoadTripping"; } }
    public string Name { get { return "Road tripping"; } }
    public string Description { get { return "Gas stations, pit stops, getting lost... and self-discovery?"; } }
    public List<string> Genres { get { return new List<string> { "adventure", "comedy", "family" }; } }
    public List<string> Types { get { return new List<string> { "Experiences" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}