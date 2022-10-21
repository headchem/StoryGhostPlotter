using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class HeroOnAMission : IAppealTerm
{
    public string Id { get { return "HeroOnAMission"; } }
    public string Name { get { return "Hero on a Mission"; } }
    public string Description { get { return "Overcoming great peril, defeating insurmountable obstacles, and saving the day in surprising ways."; } }
    public List<string> Genres { get { return new List<string> { "thriller", "action", "adventure" }; } }
    public List<string> Categories { get { return new List<string> { "Characters" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}