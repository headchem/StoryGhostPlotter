using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class VampireMenace : IAppealTerm
{
    public string Id { get { return "VampireMenace"; } }
    public string Name { get { return "Vampire menace"; } }
    public string Description { get { return "Garlic-challenged bloodsuckers."; } }
    public List<string> Genres { get { return new List<string> { "" }; } }
    public List<string> Types { get { return new List<string> { "" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}