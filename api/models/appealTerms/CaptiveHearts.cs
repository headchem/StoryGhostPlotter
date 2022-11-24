using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class CaptiveHearts : IAppealTerm
{
    public string Id { get { return "CaptiveHearts"; } }
    public string Name { get { return "Captive hearts"; } }
    public string PromptLabel { get { return "love blossoming while held as an unwilling captive"; } }
    public string Description { get { return "Romance blossoms despite the circumstances of being held against one's will."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Romance }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Situations }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}