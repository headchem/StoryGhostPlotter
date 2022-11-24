using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class SinnerRedeemed : IAppealTerm
{
    public string Id { get { return "SinnerRedeemed"; } }
    public string Name { get { return "Sinner redeemed"; } }
    public string PromptLabel { get { return "seeking forgiveness"; } }
    public string Description { get { return "Can all be forgiven with these characters who are seeking redemption?"; } }
    public List<string> Genres { get { return GenresEnum.All; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Concepts, AppealTermsCategoryEnum.LifeChallenges }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}