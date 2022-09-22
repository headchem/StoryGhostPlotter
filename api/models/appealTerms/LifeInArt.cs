using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class LifeInArt : IAppealTerm
{
    public string Id { get { return "LifeInArt"; } }
    public string Name { get { return "Life in art"; } }
    public string Description { get { return "These art-focused stories feature both broad strokes and delicate portraits."; } }
    public List<string> Genres { get { return new List<string> { "" }; } }
    public List<string> Types { get { return new List<string> { "Aficionado" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}