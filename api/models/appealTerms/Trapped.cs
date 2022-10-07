using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class Trapped : IAppealTerm
{
    public string Id { get { return "Trapped"; } }
    public string Name { get { return "Trapped"; } }
    public string Description { get { return "Think isolated cabins, Arctic research bases, submarines, graves, or elevators..."; } }
    public List<string> Genres { get { return new List<string> { "horror" }; } }
    public List<string> Types { get { return new List<string> { "Plot" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}