using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class PlayingGod : IAppealTerm
{
    public string Id { get { return "PlayingGod"; } }
    public string Name { get { return "Playing God"; } }
    public string Description { get { return "Scientific overreach leads to disaster."; } }
    public List<string> Genres { get { return new List<string> { "science fiction", "action", "adventure" }; } }
    public List<string> Types { get { return new List<string> { "Concepts and Characters", "Plot" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}