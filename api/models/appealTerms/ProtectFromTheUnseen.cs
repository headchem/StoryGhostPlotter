using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class ProtectFromTheUnseen : IAppealTerm
{
    public string Id { get { return "ProtectFromTheUnseen"; } }
    public string Name { get { return "Protect From The Unseen"; } }
    public string Description { get { return "The protagonist protects the blissfully unaware public from paranormal threats."; } }
    public List<string> Genres { get { return new List<string> { "fantasy" }; } }
    public List<string> Categories { get { return new List<string> { "Characters" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}