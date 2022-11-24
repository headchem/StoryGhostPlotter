using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class BornThisWay : IAppealTerm
{
    public string Id { get { return "BornThisWay"; } }
    public string Name { get { return "Born this way"; } }
    public string PromptLabel { get { return "innately possessing incredible skill or power"; } }
    public string Description { get { return "These characters are born with super powers."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Action, GenresEnum.Fantasy }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Characters }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}