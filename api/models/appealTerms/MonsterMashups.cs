using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class MonsterMashups : IAppealTerm
{
    public string Id { get { return "MonsterMashups"; } }
    public string Name { get { return "Monster mashups"; } }
    public string Description { get { return "Classic literature or history with an injection of horror."; } }
    public List<string> Genres { get { return new List<string> { "" }; } }
    public List<string> Types { get { return new List<string> { "" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}