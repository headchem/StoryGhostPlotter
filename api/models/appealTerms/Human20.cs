using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class Human20 : IAppealTerm
{
    public string Id { get { return "Human20"; } }
    public string Name { get { return "Human 20"; } }
    public string Description { get { return "A distinct upgrade from your run-of-the-mill human."; } }
    public List<string> Genres { get { return new List<string> { "science fiction", "action", "adventure" }; } }
    public List<string> Types { get { return new List<string> { "Concepts and Characters" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}