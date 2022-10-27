using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class EccentricDetectiveAndSidekick : IAppealTerm
{
    public string Id { get { return "EccentricDetectiveAndSidekick"; } }
    public string Name { get { return "Eccentric Detective and Sidekick"; } }
    public string Description { get { return "The sidekick is a stand-in for the reader, and struggles to match wits with the enigmatic detective."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Mystery }; } }
    public List<string> Categories { get { return new List<string> { "Characters" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}