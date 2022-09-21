using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class RobotsWithEmotions : IAppealTerm
{
    public string Id { get { return "RobotsWithEmotions"; } }
    public string Name { get { return "Robots with emotions"; } }
    public string Description { get { return "These robots DEFINITELY pass the Turing test."; } }
    public List<string> Genres { get { return new List<string> { "" }; } }
    public List<string> Types { get { return new List<string> { "" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}