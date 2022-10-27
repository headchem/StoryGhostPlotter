using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class MySquad : IAppealTerm
{
    public string Id { get { return "MySquad"; } }
    public string Name { get { return "My squad"; } }
    public string Description { get { return "Sisters from another mister swear to remain true."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Action, GenresEnum.Comedy, GenresEnum.Drama, GenresEnum.Urban }; } }
    public List<string> Categories { get { return new List<string> { "Characters" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}