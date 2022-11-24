using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class SurvivingSexualViolence : IAppealTerm
{
    public string Id { get { return "SurvivingSexualViolence"; } }
    public string Name { get { return "Surviving sexual violence"; } }
    public string PromptLabel { get { return "surviving sexual violence"; } }
    public string Description { get { return "Characters rebuild their lives after sexual violence."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Drama, GenresEnum.Urban }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.LifeChallenges }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}