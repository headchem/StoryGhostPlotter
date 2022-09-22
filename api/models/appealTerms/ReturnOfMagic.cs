using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class ReturnOfMagic : IAppealTerm
{
    public string Id { get { return "ReturnOfMagic"; } }
    public string Name { get { return "Return of magic"; } }
    public string Description { get { return "Legend becomes reality as magic reenters the world."; } }
    public List<string> Genres { get { return new List<string> { "fantasy" }; } }
    public List<string> Types { get { return new List<string> { "Plot" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}