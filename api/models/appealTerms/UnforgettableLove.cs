using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class UnforgettableLove : IAppealTerm
{
    public string Id { get { return "UnforgettableLove"; } }
    public string Name { get { return "Unforgettable love"; } }
    public string Description { get { return "Memory loss can provide a chance to start over."; } }
    public List<string> Genres { get { return new List<string> { "romance" }; } }
    public List<string> Categories { get { return new List<string> { "Plot" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}