using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class RealLifeMonsters : IAppealTerm
{
    public string Id { get { return "RealLifeMonsters"; } }
    public string Name { get { return "Real life monsters"; } }
    public string Description { get { return "Sometimes the scariest monsters are the ones beside you."; } }
    public List<string> Genres { get { return new List<string> { "horror", "thriller" }; } }
    public List<string> Categories { get { return new List<string> { "Monsters" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}