using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class ChosenFamily : IAppealTerm
{
    public string Id { get { return "ChosenFamily"; } }
    public string Name { get { return "Chosen family"; } }
    public string Description { get { return "Sometimes, you're NOT stuck with the family you were born into."; } }
    public List<string> Genres { get { return new List<string> { "" }; } }
    public List<string> Types { get { return new List<string> { "Family and Relationships" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}