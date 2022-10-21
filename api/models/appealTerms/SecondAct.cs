using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class SecondAct : IAppealTerm
{
    public string Id { get { return "SecondAct"; } }
    public string Name { get { return "Second act"; } }
    public string Description { get { return "These older characters show that life's second half has stories worth telling, too."; } }
    public List<string> Genres { get { return new List<string> { "adventure", "comedy", "family", "romance" }; } }
    public List<string> Categories { get { return new List<string> { "Concepts and Characters" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}