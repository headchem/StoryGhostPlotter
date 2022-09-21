using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class LoveInDisguise : IAppealTerm
{
    public string Id { get { return "LoveInDisguise"; } }
    public string Name { get { return "Love in disguise"; } }
    public string Description { get { return "Can love blossom between those who are not what they seem?"; } }
    public List<string> Genres { get { return new List<string> { "" }; } }
    public List<string> Types { get { return new List<string> { "" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}