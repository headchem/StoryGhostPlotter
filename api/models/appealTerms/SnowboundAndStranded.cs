using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class SnowboundAndStranded : IAppealTerm
{
    public string Id { get { return "SnowboundAndStranded"; } }
    public string Name { get { return "Snowbound And stranded"; } }
    public string Description { get { return "Things heat up in close quarters."; } }
    public List<string> Genres { get { return new List<string> { "" }; } }
    public List<string> Types { get { return new List<string> { "" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}