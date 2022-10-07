using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class WesternsUnromanticized : IAppealTerm
{
    public string Id { get { return "WesternsUnromanticized"; } }
    public string Name { get { return "Unromanticized"; } }
    public string Description { get { return "These Westerns reveal the ugly underbelly of the West, with the patina of a glamorized frontier rubbed away to give a grim, uncompromising view of the area and times."; } }
    public List<string> Genres { get { return new List<string> { "western" }; } }
    public List<string> Types { get { return new List<string> { "setting" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}