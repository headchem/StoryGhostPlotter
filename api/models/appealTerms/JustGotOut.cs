using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class JustGotOut : IAppealTerm
{
    public string Id { get { return "JustGotOut"; } }
    public string Name { get { return "Just got out"; } }
    public string Description { get { return "Back on the streets after doing time in prison."; } }
    public List<string> Genres { get { return new List<string> { "urban" }; } }
    public List<string> Types { get { return new List<string> { "Plot" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}