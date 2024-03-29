using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class MonsterMayhem : IAppealTerm
{
    public string Id { get { return "MonsterMayhem"; } }
    public string Name { get { return "Monster mayhem"; } }
    public string PromptLabel { get { return "smart kids unmasking a criminal disguised as a paranormal monster"; } }
    public string Description { get { return "Smart kids find monsters in disguise in these paranormal stories."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Horror }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Monsters, AppealTermsCategoryEnum.Situations }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}