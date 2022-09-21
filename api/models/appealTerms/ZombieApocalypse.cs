using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class ZombieApocalypse : IAppealTerm
{
    public string Id { get { return "ZombieApocalypse"; } }
    public string Name { get { return "Zombie apocalypse"; } }
    public string Description { get { return "Live free or... walk dead?"; } }
    public List<string> Genres { get { return new List<string> { "" }; } }
    public List<string> Types { get { return new List<string> { "" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}