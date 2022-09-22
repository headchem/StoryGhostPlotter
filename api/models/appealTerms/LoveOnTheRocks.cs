using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class LoveOnTheRocks : IAppealTerm
{
    public string Id { get { return "LoveOnTheRocks"; } }
    public string Name { get { return "Love on the rocks"; } }
    public string Description { get { return "The course of love does not always run smooth."; } }
    public List<string> Genres { get { return new List<string> { "comedy", "drama", "romance", "urban" }; } }
    public List<string> Types { get { return new List<string> { "Family and Relationships" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}