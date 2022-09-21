using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class UnnamedNarrator : IAppealTerm
{
    public string Id { get { return "UnnamedNarrator"; } }
    public string Name { get { return "Unnamed narrator"; } }
    public string Description { get { return "Known by false identities, aliases, titles, or simply no name at all, these narrators keep you guessing as to who they are, and whether it matters."; } }
    public List<string> Genres { get { return new List<string> { "" }; } }
    public List<string> Types { get { return new List<string> { "" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}