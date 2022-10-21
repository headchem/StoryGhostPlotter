using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class ChildNarrator : IAppealTerm
{
    public string Id { get { return "ChildNarrator"; } }
    public string Name { get { return "Child narrator"; } }
    public string Description { get { return "These stories are told from children's perspectives."; } }
    public List<string> Genres { get { return new List<string> { "adventure", "family" }; } }
    public List<string> Categories { get { return new List<string> { "Narrative Devices" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}