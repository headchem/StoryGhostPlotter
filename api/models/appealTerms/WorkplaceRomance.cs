using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class WorkplaceRomance : IAppealTerm
{
    public string Id { get { return "WorkplaceRomance"; } }
    public string Name { get { return "Workplace romance"; } }
    public string Description { get { return "Mixing business with pleasure."; } }
    public List<string> Genres { get { return new List<string> { "romance" }; } }
    public List<string> Categories { get { return new List<string> { "Setting" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}