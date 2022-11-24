using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class WeUsedToBeFriends : IAppealTerm
{
    public string Id { get { return "WeUsedToBeFriends"; } }
    public string Name { get { return "We used to be friends"; } }
    public string PromptLabel { get { return "the end of a friendship"; } }
    public string Description { get { return "Not all friendships are forever."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Comedy, GenresEnum.Drama }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Relationships, AppealTermsCategoryEnum.Characters }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}