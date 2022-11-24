using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class RookieOnTheBeat : IAppealTerm
{
    public string Id { get { return "RookieOnTheBeat"; } }
    public string Name { get { return "Rookie on the beat"; } }
    public string PromptLabel { get { return "a rookie crime fighter"; } }
    public string Description { get { return "Newbies tackle crime trying to prove they have what it takes."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Crime, GenresEnum.Mystery }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Characters, AppealTermsCategoryEnum.OccupationsAndEnterprise }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}