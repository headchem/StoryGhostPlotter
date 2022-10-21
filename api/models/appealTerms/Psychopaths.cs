using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class Psychopaths : IAppealTerm
{
    public string Id { get { return "Psychopaths"; } }
    public string Name { get { return "Psychopaths"; } }
    public string Description { get { return "Deranged villains can't be reasoned with - can their twisted personal code of conduct be decoded before they do more damage?"; } }
    public List<string> Genres { get { return new List<string> { "thriller", "action" }; } }
    public List<string> Categories { get { return new List<string> { "Characters" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}