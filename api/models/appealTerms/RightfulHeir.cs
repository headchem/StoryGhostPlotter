using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class RightfulHeir : IAppealTerm
{
    public string Id { get { return "RightfulHeir"; } }
    public string Name { get { return "Rightful heir"; } }
    public string PromptLabel { get { return "a rightful heir seeking to claim the throne"; } }
    public string Description { get { return "Usurpers and traitors stand in the way of the throne."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Fantasy, GenresEnum.History }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Characters, AppealTermsCategoryEnum.PowerStructures }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}