using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class SpyLifeInfiltrators : IAppealTerm
{
    public string Id { get { return "SpyLifeInfiltrators"; } }
    public string Name { get { return "Spy Life Infiltrators"; } }
    public string Description { get { return "These spies must stay hidden, blend in, and win the trust, while staying just one step ahead of being found out. Things get complicated when they start to form real bonds with their targets."; } }
    public List<string> Genres { get { return new List<string> { "thriller" }; } }
    public List<string> Types { get { return new List<string> { "Characters" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}