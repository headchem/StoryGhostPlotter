using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class SurvivingAbuse : IAppealTerm
{
    public string Id { get { return "SurvivingAbuse"; } }
    public string Name { get { return "Surviving abuse"; } }
    public string Description { get { return "Characters seek healing after physical or emotional abuse."; } }
    public List<string> Genres { get { return new List<string> { "" }; } }
    public List<string> Types { get { return new List<string> { "" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}