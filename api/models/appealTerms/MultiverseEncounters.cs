using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class MultiverseEncounters : IAppealTerm
{
    public string Id { get { return "MultiverseEncounters"; } }
    public string Name { get { return "Multiverse encounters"; } }
    public string Description { get { return "Wait you mean there are two of us?"; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Action, GenresEnum.Fantasy, GenresEnum.ScienceFiction }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Concepts, AppealTermsCategoryEnum.SpaceAndTime }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}