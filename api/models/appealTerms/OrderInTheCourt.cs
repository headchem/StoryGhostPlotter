using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class OrderInTheCourt : IAppealTerm
{
    public string Id { get { return "OrderInTheCourt"; } }
    public string Name { get { return "Order In The Court"; } }
    public string Description { get { return "These stories revolve around the court of law."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Drama, GenresEnum.Mystery }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Settings, AppealTermsCategoryEnum.PowerStructures }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}