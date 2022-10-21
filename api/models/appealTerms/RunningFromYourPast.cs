using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class RunningFromYourPast : IAppealTerm
{
    public string Id { get { return "RunningFromYourPast"; } }
    public string Name { get { return "Running from your past"; } }
    public string Description { get { return "These characters have secrets from their past, and they're desperate to start over."; } }
    public List<string> Genres { get { return new List<string> { "romance", "action", "adventure", "comedy", "drama", "music", "sports", "thriller", "western" }; } }
    public List<string> Categories { get { return new List<string> { "Life's Challenges" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}