using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class ProvingOnesInnocence : IAppealTerm
{
    public string Id { get { return "ProvingOnesInnocence"; } }
    public string Name { get { return "Proving ones innocence"; } }
    public string Description { get { return "Sometimes the detective is also the primary suspect."; } }
    public List<string> Genres { get { return new List<string> { "mystery", "thriller" }; } }
    public List<string> Types { get { return new List<string> { "Plot" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}