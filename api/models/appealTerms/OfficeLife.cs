using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class OfficeLife : IAppealTerm
{
    public string Id { get { return "OfficeLife"; } }
    public string Name { get { return "Office life"; } }
    public string Description { get { return "Life around the water cooler and amongst the cubicles."; } }
    public List<string> Genres { get { return new List<string> { "comedy", "drama" }; } }
    public List<string> Categories { get { return new List<string> { "Setting" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}