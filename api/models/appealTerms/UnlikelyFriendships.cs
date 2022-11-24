using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class UnlikelyFriendships : IAppealTerm
{
    public string Id { get { return "UnlikelyFriendships"; } }
    public string Name { get { return "Unlikely friendships"; } }
    public string PromptLabel { get { return "an unlikely friendship"; } }
    public string Description { get { return "Despite differences, unexpected friendships form."; } }
    public List<string> Genres { get { return GenresEnum.All; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Relationships, AppealTermsCategoryEnum.Characters }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}