using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class FishOutOfWater : IAppealTerm
{
    public string Id { get { return "FishOutOfWater"; } }
    public string Name { get { return "Fish out of water"; } }
    public string Description { get { return "Characters leave comfort zones behind and must adapt to wildly new ways of life."; } }
    public List<string> Genres { get { return new List<string> { "action", "adventure", "comedy", "drama", "romance", "science fiction", "sports", "urban", "war", "western" }; } }
    public List<string> Types { get { return new List<string> { "Concepts and Characters" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}