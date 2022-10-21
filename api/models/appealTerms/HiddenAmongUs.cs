using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class HiddenAmongUs : IAppealTerm
{
    public string Id { get { return "HiddenAmongUs"; } }
    public string Name { get { return "Hidden among us"; } }
    public string Description { get { return "There's a whole different world coexisting and hiding in plain sight."; } }
    public List<string> Genres { get { return new List<string> { "fantasy" }; } }
    public List<string> Categories { get { return new List<string> { "Setting" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}