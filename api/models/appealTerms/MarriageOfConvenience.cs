using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class MarriageOfConvenience : IAppealTerm
{
    public string Id { get { return "MarriageOfConvenience"; } }
    public string Name { get { return "Marriage of convenience"; } }
    public string Description { get { return "Expedient arrangements deepen into true love."; } }
    public List<string> Genres { get { return new List<string> { "romance" }; } }
    public List<string> Categories { get { return new List<string> { "Plot" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}