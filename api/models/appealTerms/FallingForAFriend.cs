using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class FallingForAFriend : IAppealTerm
{
    public string Id { get { return "FallingForAFriend"; } }
    public string Name { get { return "Falling for a friend"; } }
    public string Description { get { return "Discovering that friendship has more to offer."; } }
    public List<string> Genres { get { return new List<string> { "romance" }; } }
    public List<string> Types { get { return new List<string> { "Characters" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}