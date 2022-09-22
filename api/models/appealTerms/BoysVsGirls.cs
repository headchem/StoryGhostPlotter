using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class BoysVsGirls : IAppealTerm
{
    public string Id { get { return "BoysVsGirls"; } }
    public string Name { get { return "Boys vs Girls"; } }
    public string Description { get { return "It's a battle of the sexes as kids divide along gender lines."; } }
    public List<string> Genres { get { return new List<string> { "" }; } }
    public List<string> Types { get { return new List<string> { "Concepts and Characters" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}