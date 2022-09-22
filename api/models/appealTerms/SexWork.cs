using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class SexWork : IAppealTerm
{
    public string Id { get { return "SexWork"; } }
    public string Name { get { return "Sex work"; } }
    public string Description { get { return "Sometimes work in the sex industry is by choice, sometimes by necessity."; } }
    public List<string> Genres { get { return new List<string> { "urban" }; } }
    public List<string> Types { get { return new List<string> { "Plot" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}