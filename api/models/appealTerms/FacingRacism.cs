using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class FacingRacism : IAppealTerm
{
    public string Id { get { return "FacingRacism"; } }
    public string Name { get { return "Facing racism"; } }
    public string Description { get { return "Individual or systemic, racism is a lived experience."; } }
    public List<string> Genres { get { return new List<string> { "" }; } }
    public List<string> Types { get { return new List<string> { "Identity" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}