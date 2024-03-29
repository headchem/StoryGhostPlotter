using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class SolveThePuzzle : IAppealTerm
{
    public string Id { get { return "SolveThePuzzle"; } }
    public string Name { get { return "Solve the puzzle"; } }
    public string PromptLabel { get { return "solving a crime puzzle"; } }
    public string Description { get { return "Readers solve these crimes along with the characters."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Mystery }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Concepts }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}