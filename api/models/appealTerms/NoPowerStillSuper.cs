using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class NoPowerStillSuper : IAppealTerm
{
    public string Id { get { return "NoPowerStillSuper"; } }
    public string Name { get { return "No power still super"; } }
    public string Description { get { return "It takes hard work to get to be this good."; } }
    public List<string> Genres { get { return new List<string> { "action", "adventure" }; } }
    public List<string> Types { get { return new List<string> { "Characters" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}