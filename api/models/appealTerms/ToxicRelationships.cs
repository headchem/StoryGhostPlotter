using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class ToxicRelationships : IAppealTerm
{
    public string Id { get { return "ToxicRelationships"; } }
    public string Name { get { return "Toxic relationships"; } }
    public string Description { get { return "Intense characters interact in unhealthy ways."; } }
    public List<string> Genres { get { return new List<string> { "action", "drama", "horror", "thriller", "urban" }; } }
    public List<string> Types { get { return new List<string> { "Family and Relationships" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}