using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class Cursed : IAppealTerm
{
    public string Id { get { return "Cursed"; } }
    public string Name { get { return "Cursed"; } }
    public string Description { get { return "Malevolent forces have cursed these characters."; } }
    public List<string> Genres { get { return new List<string> { "horror" }; } }
    public List<string> Categories { get { return new List<string> { "Plot" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}