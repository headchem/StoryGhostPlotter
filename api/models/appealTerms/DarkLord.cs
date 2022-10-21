using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class DarkLord : IAppealTerm
{
    public string Id { get { return "DarkLord"; } }
    public string Name { get { return "Dark lord"; } }
    public string Description { get { return "These lords and ladies are assembling armies of darkness."; } }
    public List<string> Genres { get { return new List<string> { "fantasy" }; } }
    public List<string> Categories { get { return new List<string> { "Characters" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}