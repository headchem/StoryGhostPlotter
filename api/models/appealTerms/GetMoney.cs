using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class GetMoney : IAppealTerm
{
    public string Id { get { return "GetMoney"; } }
    public string Name { get { return "Get money"; } }
    public string Description { get { return "These characters are willing to sacrifice everything in the pursuit of riches."; } }
    public List<string> Genres { get { return new List<string> { "urban", "western" }; } }
    public List<string> Types { get { return new List<string> { "Plot" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}