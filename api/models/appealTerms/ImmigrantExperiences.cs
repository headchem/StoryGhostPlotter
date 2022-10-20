using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class ImmigrantExperiences : IAppealTerm
{
    public string Id { get { return "ImmigrantExperiences"; } }
    public string Name { get { return "Immigrant experiences"; } }
    public string Description { get { return "These characters experience the challenges of moving to a new country."; } }
    public List<string> Genres { get { return new List<string> { "action", "comedy", "crime", "drama", "history", "urban", "war" }; } }
    public List<string> Types { get { return new List<string> { "Experiences", "Identity" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}