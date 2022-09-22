using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class LawsOfMagic : IAppealTerm
{
    public string Id { get { return "LawsOfMagic"; } }
    public string Name { get { return "Laws of magic"; } }
    public string Description { get { return "A wizard did it! ... In accordance with a magical system."; } }
    public List<string> Genres { get { return new List<string> { "fantasy" }; } }
    public List<string> Types { get { return new List<string> { "Setting" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}