using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class ForbiddenLove : IAppealTerm
{
    public string Id { get { return "ForbiddenLove"; } }
    public string Name { get { return "Forbidden love"; } }
    public string Description { get { return "Circumstances conspire to keep lovers apart in these stories. Will the lovers beat the odds, or will fate separate?"; } }
    public List<string> Genres { get { return new List<string> { "adventure", "comedy", "drama", "war", "western" }; } }
    public List<string> Categories { get { return new List<string> { "Life's Challenges" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}