using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class HardenedProfessional : IAppealTerm
{
    public string Id { get { return "HardenedProfessional"; } }
    public string Name { get { return "HardenedProfessional"; } }
    public string Description { get { return "They've seen it all - but this time is different."; } }
    public List<string> Genres { get { return new List<string> { "mystery" }; } }
    public List<string> Types { get { return new List<string> { "Characters" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}