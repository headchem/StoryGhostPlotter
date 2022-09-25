using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class Anarchy : IAppealTerm
{
    public string Id { get { return "Anarchy"; } }
    public string Name { get { return "Anarchy"; } }
    public string Description { get { return "It's every person for themselves in wide open spaces, far from the law."; } }
    public List<string> Genres { get { return new List<string> { "western" }; } }
    public List<string> Types { get { return new List<string> { "Setting" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}