using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class Spirits : IAppealTerm
{
    public string Id { get { return "Spirits"; } }
    public string Name { get { return "Spirits"; } }
    public string Description { get { return "These ghosts have unfinished business."; } }
    public List<string> Genres { get { return new List<string> { "horror" }; } }
    public List<string> Categories { get { return new List<string> { "Plot" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}