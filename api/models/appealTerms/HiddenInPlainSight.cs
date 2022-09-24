using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class HiddenInPlainSight : IAppealTerm
{
    public string Id { get { return "HiddenInPlainSight"; } }
    public string Name { get { return "Hidden In Plain Sight"; } }
    public string Description { get { return "The least likely suspect did it, with clues that were right under our nose the entire time."; } }
    public List<string> Genres { get { return new List<string> { "mystery" }; } }
    public List<string> Types { get { return new List<string> { "Characters" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}