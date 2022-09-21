using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class EnsembleCasts : IAppealTerm
{
    public string Id { get { return "EnsembleCasts"; } }
    public string Name { get { return "Ensemble casts"; } }
    public string Description { get { return "Many characters and multiple perspectives."; } }
    public List<string> Genres { get { return new List<string> { "" }; } }
    public List<string> Types { get { return new List<string> { "" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}