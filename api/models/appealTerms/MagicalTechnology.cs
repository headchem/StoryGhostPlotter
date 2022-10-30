using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class MagicalTechnology : IAppealTerm
{
    public string Id { get { return "MagicalTechnology"; } }
    public string Name { get { return "Magical Technology"; } }
    public string Description { get { return "In a dark and grimy urban setting, magic is infused with technology. Familiar to today... but with magic, resulting in a strange but recognizable world."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Fantasy, GenresEnum.Urban, GenresEnum.ScienceFiction }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Settings }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}