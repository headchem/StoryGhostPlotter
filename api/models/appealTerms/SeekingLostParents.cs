using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class SeekingLostParents : IAppealTerm
{
    public string Id { get { return "SeekingLostParents"; } }
    public string Name { get { return "Seeking lost parents"; } }
    public string PromptLabel { get { return "seeking lost parents"; } }
    public string Description { get { return "Young characters must find their missing guardians."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Adventure, GenresEnum.Drama, GenresEnum.Family, GenresEnum.War }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Situations }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}