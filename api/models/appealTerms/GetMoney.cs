using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class GetMoney : IAppealTerm
{
    public string Id { get { return "GetMoney"; } }
    public string Name { get { return "Get money"; } }
    public string Description { get { return "These characters try to make it to the high life, by whatever means necessary."; } }
    public List<string> Genres { get { return new List<string> { "" }; } }
    public List<string> Types { get { return new List<string> { "" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}