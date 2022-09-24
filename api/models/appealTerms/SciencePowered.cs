using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class SciencePowered : IAppealTerm
{
    public string Id { get { return "SciencePowered"; } }
    public string Name { get { return "Science-Powered"; } }
    public string Description { get { return "Narratives based on scientific reasoning which can be actual or at least rationalized. Facts must not overshadow the need for excitement and adventure."; } }
    public List<string> Genres { get { return new List<string> { "science fiction" }; } }
    public List<string> Types { get { return new List<string> { "Concepts and Characters" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}