using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class GoYourOwnWay : IAppealTerm
{
    public string Id { get { return "GoYourOwnWay"; } }
    public string Name { get { return "Go your own way"; } }
    public string PromptLabel { get { return "finding one's own path in life"; } }
    public string Description { get { return "Sometimes you have to blaze your own trail and go out on your own."; } }
    public List<string> Genres { get { return GenresEnum.All; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.LifeChallenges }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}