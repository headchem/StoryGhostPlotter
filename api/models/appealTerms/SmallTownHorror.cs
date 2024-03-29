using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class SmallTownHorror : IAppealTerm
{
    public string Id { get { return "SmallTownHorror"; } }
    public string Name { get { return "Small town horror"; } }
    public string PromptLabel { get { return "horror in a small town"; } }
    public string Description { get { return "Small towns get creepy."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Horror }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Settings }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}