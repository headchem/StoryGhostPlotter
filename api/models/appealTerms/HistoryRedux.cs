using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class HistoryRedux : IAppealTerm
{
    public string Id { get { return "HistoryRedux"; } }
    public string Name { get { return "History Redux"; } }
    public string Description { get { return "What if one key point in history were changed? May be our timeline (Alternate History) or different time stream/dimension (Parallel Reality)."; } }
    public List<string> Genres { get { return new List<string> { "science fiction" }; } }
    public List<string> Categories { get { return new List<string> { "Space and Time" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}