using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class RiseOfTheMachines : IAppealTerm
{
    public string Id { get { return "RiseOfTheMachines"; } }
    public string Name { get { return "Rise of the machines"; } }
    public string Description { get { return "Robots and computers turn on their creators."; } }
    public List<string> Genres { get { return new List<string> { "" }; } }
    public List<string> Types { get { return new List<string> { "" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}