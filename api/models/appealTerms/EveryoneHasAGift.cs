using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class EveryoneHasAGift : IAppealTerm
{
    public string Id { get { return "EveryoneHasAGift"; } }
    public string Name { get { return "Everyone Has A Gift"; } }
    public string Description { get { return "In this world, everyone eventually acquires a magic power, but no two powers are the same. Some are more powerful than others, but they interact in surprising ways."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Fantasy }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Concepts }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}