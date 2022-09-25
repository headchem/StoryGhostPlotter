using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class SwappedAtBirth : IAppealTerm
{
    public string Id { get { return "SwappedAtBirth"; } }
    public string Name { get { return "Swapped At Birth"; } }
    public string Description { get { return "These characters were swapped at birth, and have very different upbringings. Fate brings them together as they wrestle with their true identities."; } }
    public List<string> Genres { get { return new List<string> { "action", "adventure", "drama" }; } }
    public List<string> Types { get { return new List<string> { "Characters", "Life Challenges" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}