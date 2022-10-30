using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class OppositesAttract : IAppealTerm
{
    public string Id { get { return "OppositesAttract"; } }
    public string Name { get { return "Opposites attract"; } }
    public string Description { get { return "These odd couples disagree about everything... except each other."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Romance }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Characters, AppealTermsCategoryEnum.Relationships }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}