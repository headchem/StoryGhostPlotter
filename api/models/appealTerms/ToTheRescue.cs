using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class ToTheRescue : IAppealTerm
{
    public string Id { get { return "ToTheRescue"; } } // different from Manhunt
    public string Name { get { return "To the rescue"; } }
    public string Description { get { return "Someone always needs saving."; } }
    public List<string> Genres { get { return new List<string> { "fantasy" }; } }
    public List<string> Types { get { return new List<string> { "Plot" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}