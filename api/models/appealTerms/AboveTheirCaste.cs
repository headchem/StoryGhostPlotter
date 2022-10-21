using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class AboveTheirCaste : IAppealTerm
{
    public string Id { get { return "AboveTheirCaste"; } }
    public string Name { get { return "Above Their Caste"; } }
    public string Description { get { return "This character sets out to earn upward mobility in the rigid caste system they were born into."; } }
    public List<string> Genres { get { return new List<string> { "action", "drama", "fantasy" }; } }
    public List<string> Categories { get { return new List<string> { "Characters", "Life Challenges" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}