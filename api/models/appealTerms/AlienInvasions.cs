using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class AlienInvasions : IAppealTerm
{
    public string Id { get { return "AlienInvasions"; } }
    public string Name { get { return "Alien invasions"; } }
    public string Description { get { return "Extraterrestrial lifeforms attack Earth."; } }
    public List<string> Genres { get { return new List<string> { "" }; } }
    public List<string> Types { get { return new List<string> { "" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}