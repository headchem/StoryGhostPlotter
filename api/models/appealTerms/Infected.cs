using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class Infected : IAppealTerm
{
    public string Id { get { return "Infected"; } }
    public string Name { get { return "Infected"; } }
    public string Description { get { return "A mysterious disease is sweeping the world, turning everyday living into a nightmare."; } }
    public List<string> Genres { get { return new List<string> { "horror" }; } }
    public List<string> Types { get { return new List<string> { "Plot" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}