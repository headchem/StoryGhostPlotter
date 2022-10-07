using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class WesternsAfricanAmericansInTheWest : IAppealTerm
{
    public string Id { get { return "WesternsAfricanAmericansInTheWest"; } }
    public string Name { get { return "African Americans In The West"; } }
    public string Description { get { return "Up until recently, cowboys have been most often portrayed as white, but in truth there were many who were Hispanic and black. African American soldiers were seen frequently enough that Native Americans created a name for them, \"buffalo soldiers.\""; } }
    public List<string> Genres { get { return new List<string> { "western" }; } }
    public List<string> Types { get { return new List<string> { "characters" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}