using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class SolveThePuzzle : IAppealTerm
{
    public string Id { get { return "SolveThePuzzle"; } }
    public string Name { get { return "Solve the puzzle"; } }
    public string Description { get { return "Readers solve these crimes along with the characters."; } }
    public List<string> Genres { get { return new List<string> { "mystery" }; } }
    public List<string> Types { get { return new List<string> { "Plot" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}