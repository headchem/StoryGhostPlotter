using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class FishOutOfWater : IAppealTerm
{
    public string Id { get { return "FishOutOfWater"; } }
    public string Name { get { return "Fish out of water"; } }
    public string Description { get { return "Characters leave comfort zones behind."; } }
    public List<string> Genres { get { return new List<string> { "" }; } }
    public List<string> Types { get { return new List<string> { "" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}