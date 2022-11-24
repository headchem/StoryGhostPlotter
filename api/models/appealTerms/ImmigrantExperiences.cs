using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class ImmigrantExperiences : IAppealTerm
{
    public string Id { get { return "ImmigrantExperiences"; } }
    public string Name { get { return "Immigrant experiences"; } }
    public string PromptLabel { get { return "immigrant experiences"; } }
    public string Description { get { return "These characters experience the challenges of moving to a new country."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Adventure, GenresEnum.Comedy, GenresEnum.Drama, GenresEnum.History, GenresEnum.Urban, GenresEnum.Western }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Situations, AppealTermsCategoryEnum.LifeChallenges }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}