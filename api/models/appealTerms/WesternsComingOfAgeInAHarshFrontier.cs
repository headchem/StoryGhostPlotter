using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class WesternsComingOfAgeInAHarshFrontier : IAppealTerm
{
    public string Id { get { return "WesternsComingOfAgeInAHarshFrontier"; } }
    public string Name { get { return "Coming Of Age In A Harsh Frontier"; } }
    public string Description { get { return "Traditionally in this genre, coming of age could be described as \"boy becomes man,\" but now protagonists of both genders are experiencing the trials and travails of the journey from childhood to adulthood on a harsh frontier."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Western }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Characters }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}