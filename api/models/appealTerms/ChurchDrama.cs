using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class ChurchDrama : IAppealTerm
{
    public string Id { get { return "ChurchDrama"; } }
    public string Name { get { return "Church drama"; } }
    public string Description { get { return "There's nothing holy about the scandals happening here."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Drama, GenresEnum.History, GenresEnum.Urban }; } }
    public List<string> Categories { get { return new List<string> { "Setting" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}