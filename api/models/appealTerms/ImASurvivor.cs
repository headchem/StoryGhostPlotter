using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class ImASurvivor : IAppealTerm
{
    public string Id { get { return "ImASurvivor"; } }
    public string Name { get { return "Im a survivor"; } }
    public string Description { get { return "Characters emerge from tough situations and seek power and healing."; } }
    public List<string> Genres { get { return new List<string> { "" }; } }
    public List<string> Types { get { return new List<string> { "" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}