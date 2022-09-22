using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class CosmicAndMysticalBeginnings : IAppealTerm
{
    public string Id { get { return "CosmicAndMysticalBeginnings"; } }
    public string Name { get { return "Cosmic and mystical beginnings"; } }
    public string Description { get { return "Part superhero, part wizard or god."; } }
    public List<string> Genres { get { return new List<string> { "action", "adventure" }; } }
    public List<string> Types { get { return new List<string> { "Characters" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}