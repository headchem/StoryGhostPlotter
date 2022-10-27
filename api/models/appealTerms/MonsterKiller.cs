using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class MonsterKiller : IAppealTerm
{
    public string Id { get { return "MonsterKiller"; } }
    public string Name { get { return "Monster Killer"; } }
    public string Description { get { return "This character does one thing really well - kill monsters. They are feared, sought after, and sometimes hunted themselves."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Fantasy }; } }
    public List<string> Categories { get { return new List<string> { "Characters" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}