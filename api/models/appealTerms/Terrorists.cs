using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class Terrorists : IAppealTerm
{
    public string Id { get { return "Terrorists"; } }
    public string Name { get { return "Terrorists"; } }
    public string Description { get { return "A violent clash of cultures with extremist ideologies."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Thriller, GenresEnum.War }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Situations }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}