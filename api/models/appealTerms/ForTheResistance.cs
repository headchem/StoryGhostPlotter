using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class ForTheResistance : IAppealTerm
{
    public string Id { get { return "ForTheResistance"; } }
    public string Name { get { return "For the resistance"; } }
    public string Description { get { return "These freedom fighters won't give up fighting for the cause they believe in."; } }
    public List<string> Genres { get { return new List<string> { "science fiction", "fantasy" }; } }
    public List<string> Types { get { return new List<string> { "Apocalyptic and Dystopian", "plot" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}