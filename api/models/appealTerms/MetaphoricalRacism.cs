using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class MetaphoricalRacism : IAppealTerm
{
    public string Id { get { return "MetaphoricalRacism"; } }
    public string Name { get { return "Metaphorical racism"; } }
    public string Description { get { return "Think elves who hate dwarves, or magic users who must hide their powers."; } }
    public List<string> Genres { get { return new List<string> { "fantasy" }; } }
    public List<string> Types { get { return new List<string> { "Plot" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}