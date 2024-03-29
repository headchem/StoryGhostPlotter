using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class CourtIntrigue : IAppealTerm
{
    public string Id { get { return "CourtIntrigue"; } }
    public string Name { get { return "Court intrigue"; } }
    public string PromptLabel { get { return "alliances and betrayals in the royal court in the pursuit of political power"; } }
    public string Description { get { return "Politics, alliances, affairs and betrayals in the royal court in the pursuit of political power."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Fantasy, GenresEnum.History, GenresEnum.Drama, GenresEnum.Romance }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Concepts, AppealTermsCategoryEnum.PowerStructures }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}