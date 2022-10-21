using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class SinnerRedeemed : IAppealTerm
{
    public string Id { get { return "SinnerRedeemed"; } }
    public string Name { get { return "Sinner redeemed"; } }
    public string Description { get { return "All can be forgiven."; } }
    public List<string> Genres { get { return new List<string> { "urban" }; } }
    public List<string> Categories { get { return new List<string> { "Plot" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}