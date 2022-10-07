using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class WesternsInModernTimes : IAppealTerm
{
    public string Id { get { return "WesternsInModernTimes"; } }
    public string Name { get { return "Westerns In Modern Times"; } }
    public string Description { get { return "The qualities that make Western heroes popular are still inherent in the children of the West today. The following list demonstrates some of the cultural diversity of the region and the changes that have occurred in the twentieth century."; } }
    public List<string> Genres { get { return new List<string> { "western" }; } }
    public List<string> Types { get { return new List<string> { "setting" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}