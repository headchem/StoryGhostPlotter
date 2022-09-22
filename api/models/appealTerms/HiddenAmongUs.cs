using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class HiddenAmongUs : IAppealTerm
{
    public string Id { get { return "HiddenAmongUs"; } }
    public string Name { get { return "Hidden among us"; } }
    public string Description { get { return "There's a whole world with the world as we know it."; } }
    public List<string> Genres { get { return new List<string> { "fantasy" }; } }
    public List<string> Types { get { return new List<string> { "Setting" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}