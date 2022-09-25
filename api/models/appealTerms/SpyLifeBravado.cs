using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class SpyLifeBravado : IAppealTerm
{
    public string Id { get { return "SpyLifeBravado"; } }
    public string Name { get { return "Spy Life Bravado"; } }
    public string Description { get { return "These special agents are the best of the best, and they know it. Trained by the government with gadgets galore - these spies have a tendency to break to rules."; } }
    public List<string> Genres { get { return new List<string> { "thriller" }; } }
    public List<string> Types { get { return new List<string> { "Characters" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}