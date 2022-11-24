using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class BattleRoyale : IAppealTerm
{
    public string Id { get { return "BattleRoyale"; } }
    public string Name { get { return "Battle royale"; } }
    public string PromptLabel { get { return "high-stakes competitions"; } }
    public string Description { get { return "People are pitted against each other in high-stakes, and sometimes deadly, competitions."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.ScienceFiction, GenresEnum.Fantasy, GenresEnum.Horror }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.ApocalypticAndDystopian }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}