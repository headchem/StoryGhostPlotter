using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class ScienceGoneTooFar : IAppealTerm
{
    public string Id { get { return "ScienceGoneTooFar"; } }
    public string Name { get { return "Science Gone Too Far"; } }
    public string PromptLabel { get { return "science pushed beyond ethical boundaries"; } }
    public string Description { get { return "Science and technology pushed far beyond ethical boundaries, and humankind's overreach results in conflict with nature."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.ScienceFiction, GenresEnum.History, GenresEnum.Thriller, GenresEnum.Horror }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Concepts, AppealTermsCategoryEnum.ApocalypticAndDystopian }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}