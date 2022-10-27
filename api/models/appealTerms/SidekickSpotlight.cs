using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class SidekickSpotlight : IAppealTerm
{
    public string Id { get { return "SidekickSpotlight"; } }
    public string Name { get { return "Sidekick spotlight"; } }
    public string Description { get { return "Sidekicks get a chance to be in the spotlight."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Action, GenresEnum.Adventure, GenresEnum.Fantasy, GenresEnum.Sports, GenresEnum.Family }; } }
    public List<string> Categories { get { return new List<string> { "Characters" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}