using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class OneNightToForever : IAppealTerm
{
    public string Id { get { return "OneNightToForever"; } }
    public string Name { get { return "One night to forever"; } }
    public string Description { get { return "A brief fling turns out to have staying power."; } }
    public List<string> Genres { get { return new List<string> { "" }; } }
    public List<string> Types { get { return new List<string> { "" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}