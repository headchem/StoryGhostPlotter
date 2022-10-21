using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class WesternsInModernTimes : IAppealTerm
{
    public string Id { get { return "WesternsInModernTimes"; } }
    public string Name { get { return "Westerns In Modern Times"; } }
    public string Description { get { return "The qualities that make Western heroes popular are still inherent in the children of the West today. These stories demonstrate the cultural diversity of the region and the changes that have occurred in the twentieth century."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Western }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Settings }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}