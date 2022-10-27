using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class ImASurvivor : IAppealTerm
{
    public string Id { get { return "ImASurvivor"; } }
    public string Name { get { return "I'm a survivor"; } }
    public string Description { get { return "Characters emerge from tough situations and seek power and healing."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Action, GenresEnum.Drama, GenresEnum.History, GenresEnum.Urban, GenresEnum.War }; } }
    public List<string> Categories { get { return new List<string> { "Characters" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}