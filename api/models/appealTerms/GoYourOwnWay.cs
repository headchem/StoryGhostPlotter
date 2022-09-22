using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class GoYourOwnWay : IAppealTerm
{
    public string Id { get { return "GoYourOwnWay"; } }
    public string Name { get { return "Go your own way"; } }
    public string Description { get { return "Sometimes you have to blaze your own trail."; } }
    public List<string> Genres { get { return new List<string> { "action", "adventure", "comedy", "drama", "music", "sports", "thriller", "western" }; } }
    public List<string> Types { get { return new List<string> { "Life's Challenges" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}