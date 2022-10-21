using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class RobotsWithEmotions : IAppealTerm
{
    public string Id { get { return "RobotsWithEmotions"; } }
    public string Name { get { return "Robots with emotions"; } }
    public string Description { get { return "These robots definitely pass the Turing test, easily convincing us of their humanity."; } }
    public List<string> Genres { get { return new List<string> { "science fiction" }; } }
    public List<string> Categories { get { return new List<string> { "Aliens and Robots" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}