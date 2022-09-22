using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class NoStringsAttached : IAppealTerm
{
    public string Id { get { return "NoStringsAttached"; } }
    public string Name { get { return "No strings attached"; } }
    public string Description { get { return "Not \"dating,\" just... having fun."; } }
    public List<string> Genres { get { return new List<string> { "romance" }; } }
    public List<string> Types { get { return new List<string> { "Plot" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}