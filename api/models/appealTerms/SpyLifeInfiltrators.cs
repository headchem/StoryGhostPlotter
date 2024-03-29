using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class SpyLifeInfiltrators : IAppealTerm
{
    public string Id { get { return "SpyLifeInfiltrators"; } }
    public string Name { get { return "Spy Life Infiltrators"; } }
    public string PromptLabel { get { return "a spy who must remain undetected"; } }
    public string Description { get { return "These spies must stay hidden, blend in, and win trust, while staying just one step ahead of being found out."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Action, GenresEnum.History, GenresEnum.War, GenresEnum.Thriller }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Secrets, AppealTermsCategoryEnum.Characters, AppealTermsCategoryEnum.OccupationsAndEnterprise }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}