using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class LivingWhileDying : IAppealTerm
{
    public string Id { get { return "LivingWhileDying"; } }
    public string Name { get { return "Living while dying"; } }
    public string Description { get { return "These characters grow up in the shadow of a serious or terminal illness."; } }
    public List<string> Genres { get { return new List<string> { "" }; } }
    public List<string> Types { get { return new List<string> { "Life's Challenges" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}