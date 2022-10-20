using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class FamilyGatherings : IAppealTerm
{
    public string Id { get { return "FamilyGatherings"; } }
    public string Name { get { return "Family gatherings"; } }
    public string Description { get { return "When families get together, personal histories and grudges collide."; } }
    public List<string> Genres { get { return new List<string> { "comedy", "drama", "family", "urban" }; } }
    public List<string> Types { get { return new List<string> { "Family and Relationships" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}