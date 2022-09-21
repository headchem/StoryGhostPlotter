using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class SeekingLostParents : IAppealTerm
{
    public string Id { get { return "SeekingLostParents"; } }
    public string Name { get { return "Seeking lost parents"; } }
    public string Description { get { return "Young heroes must find their missing guardians."; } }
    public List<string> Genres { get { return new List<string> { "" }; } }
    public List<string> Types { get { return new List<string> { "" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}