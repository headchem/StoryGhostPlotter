using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class MonsterMashups : IAppealTerm
{
    public string Id { get { return "MonsterMashups"; } }
    public string Name { get { return "Monster mashups"; } }
    public string PromptLabel { get { return "classic literature with an injection of horror"; } }
    public string Description { get { return "Classic literature or history with an injection of horror."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Horror }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Style }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}