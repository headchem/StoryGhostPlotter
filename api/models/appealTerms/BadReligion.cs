using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class BadReligion : IAppealTerm
{
    public string Id { get { return "BadReligion"; } }
    public string Name { get { return "Bad religion"; } }
    public string Description { get { return "The inhabitants of these worlds have a god problem."; } }
    public List<string> Genres { get { return new List<string> { "fantasy" }; } }
    public List<string> Categories { get { return new List<string> { "Plot" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}