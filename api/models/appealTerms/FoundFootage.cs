using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class FoundFootage : IAppealTerm
{
    public string Id { get { return "FoundFootage"; } }
    public string Name { get { return "Found footage"; } }
    public string Description { get { return "Framing devices (such as letters or diaries) highlight horrific events in real time."; } }
    public List<string> Genres { get { return new List<string> { "horror" }; } }
    public List<string> Categories { get { return new List<string> { "Style" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}