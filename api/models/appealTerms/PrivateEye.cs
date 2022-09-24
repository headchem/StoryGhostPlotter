using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class PrivateEye : IAppealTerm
{
    public string Id { get { return "PrivateEye"; } }
    public string Name { get { return "Private Eye"; } }
    public string Description { get { return "These private investigators take the cases rejected by the establishment - and they work alone."; } }
    public List<string> Genres { get { return new List<string> { "mystery" }; } }
    public List<string> Types { get { return new List<string> { "Characters" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}