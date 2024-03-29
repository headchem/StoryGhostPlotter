using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class RaisedByTheStreets : IAppealTerm
{
    public string Id { get { return "RaisedByTheStreets"; } }
    public string Name { get { return "Raised by the streets"; } }
    public string PromptLabel { get { return "being raised by the streets"; } }
    public string Description { get { return "Growing up amidst gangs, drugs, and desperation."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Crime, GenresEnum.Urban }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Settings, AppealTermsCategoryEnum.LifeChallenges }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}