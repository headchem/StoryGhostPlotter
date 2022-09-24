using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class HiddenAlienPockets : IAppealTerm
{
    public string Id { get { return "HiddenAlienPockets"; } }
    public string Name { get { return "Hidden Alien Pockets"; } }
    public string Description { get { return "They were watching and manipulating us from the shadows."; } }
    public List<string> Genres { get { return new List<string> { "science fiction" }; } }
    public List<string> Types { get { return new List<string> { "Concepts and Characters" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}