using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class ScienceFictionBootCamp : IAppealTerm
{
    public string Id { get { return "ScienceFictionBootCamp"; } }
    public string Name { get { return "Science fiction boot camp"; } }
    public string PromptLabel { get { return "a space-age military boot camp"; } }
    public string Description { get { return "Ten-hut! Boot camp meets space camp."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.ScienceFiction, GenresEnum.War }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Concepts, AppealTermsCategoryEnum.Settings }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}