using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class LifeAfterHighSchool : IAppealTerm
{
    public string Id { get { return "LifeAfterHighSchool"; } }
    public string Name { get { return "Life after high school"; } }
    public string Description { get { return "Surviving high school is only half the battle."; } }
    public List<string> Genres { get { return new List<string> { "" }; } }
    public List<string> Types { get { return new List<string> { "Experiences" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}