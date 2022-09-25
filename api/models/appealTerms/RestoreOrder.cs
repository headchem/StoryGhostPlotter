using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class RestoreOrder : IAppealTerm
{
    public string Id { get { return "RestoreOrder"; } }
    public string Name { get { return "Restore Order"; } }
    public string Description { get { return "The protagonist has a strong moral compass and does whatever it takes to restore order and justice, even if nobody is watching."; } }
    public List<string> Genres { get { return new List<string> { "western" }; } }
    public List<string> Types { get { return new List<string> { "Characters" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}