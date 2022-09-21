using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class WerewolvesAmongUs : IAppealTerm
{
    public string Id { get { return "WerewolvesAmongUs"; } }
    public string Name { get { return "Werewolves among us"; } }
    public string Description { get { return "Beware the full moon!"; } }
    public List<string> Genres { get { return new List<string> { "" }; } }
    public List<string> Types { get { return new List<string> { "" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}