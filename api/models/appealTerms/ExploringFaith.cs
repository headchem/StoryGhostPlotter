using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class ExploringFaith : IAppealTerm
{
    public string Id { get { return "ExploringFaith"; } }
    public string Name { get { return "Exploring faith"; } }
    public string Description { get { return "Characters strive to balance faith with living their lives."; } }
    public List<string> Genres { get { return new List<string> { "drama" }; } }
    public List<string> Types { get { return new List<string> { "Personal Development" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}