using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class ScienceFictionBootCamp : IAppealTerm
{
    public string Id { get { return "ScienceFictionBootCamp"; } }
    public string Name { get { return "Science fiction boot camp"; } }
    public string Description { get { return "Ten-hut! Boot camp meets space camp."; } }
    public List<string> Genres { get { return new List<string> { "" }; } }
    public List<string> Types { get { return new List<string> { "" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}