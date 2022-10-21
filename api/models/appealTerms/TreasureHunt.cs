using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class TreasureHunt : IAppealTerm
{
    public string Id { get { return "TreasureHunt"; } }
    public string Name { get { return "Treasure Hunt"; } }
    public string Description { get { return "Can the hero get to the treasure before it's gone? Maps and clues take us to exotic locales."; } }
    public List<string> Genres { get { return new List<string> { "adventure", "thriller" }; } }
    public List<string> Categories { get { return new List<string> { "Plot" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}