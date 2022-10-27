using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class GettingTogetherForTheKids : IAppealTerm
{
    public string Id { get { return "GettingTogetherForTheKids"; } }
    public string Name { get { return "Getting together for the kids"; } }
    public string Description { get { return "An unplanned pregnancy leads to a committed relationship."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Romance }; } }
    public List<string> Categories { get { return new List<string> { "Baby On Board" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}