using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class WesternsArmyInTheWest : IAppealTerm
{
    public string Id { get { return "WesternsArmyInTheWest"; } }
    public string Name { get { return "Army In The West"; } }
    public string Description { get { return "The Indian wars and the presence of ex-soldiers in the aftermath of the Civil War brought an often lawless military presence to the West."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Western }; } }
    public List<string> Categories { get { return new List<string> { "setting" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}