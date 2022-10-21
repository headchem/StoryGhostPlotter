using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class TooPowerfulToContain : IAppealTerm
{
    public string Id { get { return "TooPowerfulToContain"; } }
    public string Name { get { return "Too powerful to contain"; } }
    public string Description { get { return "Magic in these stories has explosive consequences."; } }
    public List<string> Genres { get { return new List<string> { "fantasy" }; } }
    public List<string> Categories { get { return new List<string> { "Plot" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}