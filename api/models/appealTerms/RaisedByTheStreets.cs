using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class RaisedByTheStreets : IAppealTerm
{
    public string Id { get { return "RaisedByTheStreets"; } }
    public string Name { get { return "Raised by the streets"; } }
    public string Description { get { return "Growing up amidst gangs, drugs, and desperation."; } }
    public List<string> Genres { get { return new List<string> { "" }; } }
    public List<string> Types { get { return new List<string> { "" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}