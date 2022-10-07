using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class LifeInSmallTowns : IAppealTerm
{
    public string Id { get { return "LifeInSmallTowns"; } }
    public string Name { get { return "Life in small towns"; } }
    public string Description { get { return "Everyone knows everyone else in these communities."; } }
    public List<string> Genres { get { return new List<string> { "comedy", "drama", "urban", "western" }; } }
    public List<string> Types { get { return new List<string> { "Experiences" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}