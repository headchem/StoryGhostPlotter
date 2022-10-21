using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class WesternsTexasAndMexico : IAppealTerm
{
    public string Id { get { return "WesternsTexasAndMexico"; } }
    public string Name { get { return "Texas And Mexico"; } }
    public string Description { get { return "The border country and the American settlement of Mexican lands provide an arena for heroics where honor meant more than the law."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Western }; } }
    public List<string> Categories { get { return new List<string> { "setting" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}