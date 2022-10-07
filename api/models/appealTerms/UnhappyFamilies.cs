using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class UnhappyFamilies : IAppealTerm
{
    public string Id { get { return "UnhappyFamilies"; } }
    public string Name { get { return "Unhappy families"; } }
    public string Description { get { return "Family dysfunction is front and center."; } }
    public List<string> Genres { get { return new List<string> { "drama", "urban" }; } }
    public List<string> Types { get { return new List<string> { "Family and Relationships" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}