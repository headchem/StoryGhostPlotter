using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class HumanAndAnimalBonds : IAppealTerm
{
    public string Id { get { return "HumanAndAnimalBonds"; } }
    public string Name { get { return "Human and animal bonds"; } }
    public string Description { get { return "These stories explore our relationships with animals."; } }
    public List<string> Genres { get { return new List<string> { "adventure", "comedy", "drama", "family", "war", "western" }; } }
    public List<string> Types { get { return new List<string> { "Concepts and Characters" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}