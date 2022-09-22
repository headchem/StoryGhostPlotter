using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class TheButlerDidIt : IAppealTerm
{
    public string Id { get { return "TheButlerDidIt"; } }
    public string Name { get { return "The butler did it"; } }
    public string Description { get { return "Country estates can hide secrets and bodies!"; } }
    public List<string> Genres { get { return new List<string> { "mystery" }; } }
    public List<string> Types { get { return new List<string> { "Setting" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}