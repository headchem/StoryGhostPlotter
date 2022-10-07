using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class BabyDrama : IAppealTerm
{
    public string Id { get { return "BabyDrama"; } }
    public string Name { get { return "Baby drama"; } }
    public string Description { get { return "Conflicts revolve around matters of paternity and unplanned pregnancies."; } }
    public List<string> Genres { get { return new List<string> { "urban" }; } }
    public List<string> Types { get { return new List<string> { "Plot" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}