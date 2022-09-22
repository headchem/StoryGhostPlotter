using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class SurvivingSexualViolence : IAppealTerm
{
    public string Id { get { return "SurvivingSexualViolence"; } }
    public string Name { get { return "Surviving sexual violence"; } }
    public string Description { get { return "Characters rebuild their lives after sexual violence."; } }
    public List<string> Genres { get { return new List<string> { "drama", "urban" }; } }
    public List<string> Types { get { return new List<string> { "Life's Challenges" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}