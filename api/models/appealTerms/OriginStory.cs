using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class OriginStory : IAppealTerm
{
    public string Id { get { return "OriginStory"; } }
    public string Name { get { return "Origin story"; } }
    public string Description { get { return "Gather round and learn how it all began."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Adventure, GenresEnum.Family, GenresEnum.Fantasy, GenresEnum.History, GenresEnum.ScienceFiction }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Concepts, AppealTermsCategoryEnum.Characters }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}