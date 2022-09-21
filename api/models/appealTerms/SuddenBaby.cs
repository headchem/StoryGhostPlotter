using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class SuddenBaby : IAppealTerm
{
    public string Id { get { return "SuddenBaby"; } }
    public string Name { get { return "Sudden baby"; } }
    public string Description { get { return "Becoming the guardian of a child leads to romance."; } }
    public List<string> Genres { get { return new List<string> { "" }; } }
    public List<string> Types { get { return new List<string> { "" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}