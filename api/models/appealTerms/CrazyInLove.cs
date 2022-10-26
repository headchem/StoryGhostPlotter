using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class CrazyInLove : IAppealTerm
{
    public string Id { get { return "CrazyInLove"; } }
    public string Name { get { return "Crazy in love"; } }
    public string Description { get { return "These couples remain devoted through every predicament."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Romance, GenresEnum.Drama }; } }
    public List<string> Categories { get { return new List<string> { "Characters" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}