using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class DealingWithPhysicalIllness : IAppealTerm
{
    public string Id { get { return "DealingWithPhysicalIllness"; } }
    public string Name { get { return "Dealing with physical illness"; } }
    public string PromptLabel { get { return "coping with sickness"; } }
    public string Description { get { return "Characters cope with physical sickness."; } }
    public List<string> Genres { get { return GenresEnum.All; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.LifeChallenges }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}