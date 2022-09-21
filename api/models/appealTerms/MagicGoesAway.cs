using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class MagicGoesAway : IAppealTerm
{
    public string Id { get { return "MagicGoesAway"; } }
    public string Name { get { return "Magic goes away"; } }
    public string Description { get { return "If it's lost, can it be found again?"; } }
    public List<string> Genres { get { return new List<string> { "" }; } }
    public List<string> Types { get { return new List<string> { "" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}