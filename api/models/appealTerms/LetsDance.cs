using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class LetsDance : IAppealTerm
{
    public string Id { get { return "LetsDance"; } }
    public string Name { get { return "Lets dance"; } }
    public string Description { get { return "From class to recital, these stories will put you in motion."; } }
    public List<string> Genres { get { return new List<string> { "family", "music" }; } }
    public List<string> Types { get { return new List<string> { "Personal Development" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}