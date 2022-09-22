using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class DealingWithMentalIllness : IAppealTerm
{
    public string Id { get { return "DealingWithMentalIllness"; } }
    public string Name { get { return "Dealing with mental illness"; } }
    public string Description { get { return "The mind can be the source of our greatest challenges."; } }
    public List<string> Genres { get { return new List<string> { "" }; } }
    public List<string> Types { get { return new List<string> { "Life's Challenges" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}