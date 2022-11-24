using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class WesternsAfricanAmericansInTheWest : IAppealTerm
{
    public string Id { get { return "WesternsAfricanAmericansInTheWest"; } }
    public string Name { get { return "African Americans In The West"; } }
    public string PromptLabel { get { return "African Americans in the Wild West"; } }
    //public string Description { get { return "Up until recently, cowboys have been most often portrayed as white, but in truth there were many who were Hispanic and black. African American soldiers were seen frequently enough that Native Americans created a name for them, \"buffalo soldiers.\""; } }
    public string Description { get { return "Known as \"buffalo soldiers\" these cowboys come from non-white backgrounds."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Western }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Characters }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}