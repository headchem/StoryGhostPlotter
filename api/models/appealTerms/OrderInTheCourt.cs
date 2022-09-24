using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class OrderInTheCourt : IAppealTerm
{
    public string Id { get { return "OrderInTheCourt"; } }
    public string Name { get { return "Order In The Court"; } }
    public string Description { get { return "These mysteries are solved in the court of law."; } }
    public List<string> Genres { get { return new List<string> { "mystery" }; } }
    public List<string> Types { get { return new List<string> { "Setting" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}