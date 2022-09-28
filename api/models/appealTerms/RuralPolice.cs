using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class RuralPolice : IAppealTerm
{
    public string Id { get { return "RuralPolice"; } }
    public string Name { get { return "Rural police"; } }
    public string Description { get { return "Crime is not absent in rural areas... it's just more spread out."; } }
    public List<string> Genres { get { return new List<string> { "mystery" }; } }
    public List<string> Types { get { return new List<string> { "Setting" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}