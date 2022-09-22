using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class GetInTheGame : IAppealTerm
{
    public string Id { get { return "GetInTheGame"; } }
    public string Name { get { return "Get in the game"; } }
    public string Description { get { return "In sports, everyone roots for the underdog."; } }
    public List<string> Genres { get { return new List<string> { "sports" }; } }
    public List<string> Types { get { return new List<string> { "" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}