using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class RebootsAndRetcons : IAppealTerm
{
    public string Id { get { return "RebootsAndRetcons"; } }
    public string Name { get { return "Reboots and retcons"; } }
    public string Description { get { return "New storyline, new setting, new clothes, new attitude!"; } }
    public List<string> Genres { get { return new List<string> { "action", "adventure" }; } }
    public List<string> Types { get { return new List<string> { "Plot" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}