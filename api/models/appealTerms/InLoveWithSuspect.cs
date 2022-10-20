using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class InLoveWithSuspect : IAppealTerm
{
    public string Id { get { return "InLoveWithSuspect"; } }
    public string Name { get { return "In Love With Suspect"; } }
    public string Description { get { return "Can the investigator stay objective when they fall in love with a suspect?"; } }
    public List<string> Genres { get { return new List<string> { "mystery", "romance" }; } }
    public List<string> Types { get { return new List<string> { "Characters" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}