using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class Manhunt : IAppealTerm
{
    public string Id { get { return "Manhunt"; } } // different than ToTheRescue
    public string Name { get { return "Manhunt"; } }
    public string Description { get { return "Stories revolving around the search for someone who is either on the run, hiding, or missing."; } }
    public List<string> Genres { get { return new List<string> { "drama" }; } }
    public List<string> Categories { get { return new List<string> { "Narrative Devices" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}