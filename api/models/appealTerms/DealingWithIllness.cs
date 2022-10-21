using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class DealingWithIllness : IAppealTerm
{
    public string Id { get { return "DealingWithIllness"; } }
    public string Name { get { return "Dealing with illness"; } }
    public string Description { get { return "Characters cope with sickness."; } }
    public List<string> Genres { get { return new List<string> { "adventure", "drama" }; } }
    public List<string> Categories { get { return new List<string> { "Life's Challenges" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}