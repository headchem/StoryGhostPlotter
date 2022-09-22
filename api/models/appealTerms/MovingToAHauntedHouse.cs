using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class MovingToAHauntedHouse : IAppealTerm
{
    public string Id { get { return "MovingToAHauntedHouse"; } }
    public string Name { get { return "Moving to a haunted house"; } }
    public string Description { get { return "Spoiler alert moving was a BAD idea!"; } }
    public List<string> Genres { get { return new List<string> { "horror" }; } }
    public List<string> Types { get { return new List<string> { "Setting" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}