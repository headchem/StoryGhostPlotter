using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class BrandNewYou : IAppealTerm
{
    public string Id { get { return "BrandNewYou"; } }
    public string Name { get { return "Brand new you"; } }
    public string Description { get { return "Personal changes lead to self-discovery."; } }
    public List<string> Genres { get { return new List<string> { "" }; } }
    public List<string> Types { get { return new List<string> { "" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}