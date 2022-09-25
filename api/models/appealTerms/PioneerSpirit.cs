using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class PioneerSpirit : IAppealTerm
{
    public string Id { get { return "PioneerSpirit"; } }
    public string Name { get { return "Pioneer Spirit"; } }
    public string Description { get { return "A new frontier is ripe for the taking - all that's needed for these homesteaders is to survive the trip there, and hope the locals don't object."; } }
    public List<string> Genres { get { return new List<string> { "western" }; } }
    public List<string> Types { get { return new List<string> { "Setting" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}