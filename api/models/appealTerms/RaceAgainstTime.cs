using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class RaceAgainstTime : IAppealTerm
{
    public string Id { get { return "RaceAgainstTime"; } }
    public string Name { get { return "Race against time"; } }
    public string PromptLabel { get { return "a race against time"; } }
    public string Description { get { return "The clock is ticking!"; } }
    public List<string> Genres { get { return GenresEnum.All; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Situations }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}