using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class EngenderingGender : IAppealTerm
{
    public string Id { get { return "EngenderingGender"; } }
    public string Name { get { return "Engendering gender"; } }
    public string Description { get { return "These stories challenge and explore concepts of gender."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Drama, GenresEnum.History, GenresEnum.Urban }; } }
    public List<string> Categories { get { return new List<string> { "Identity" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}