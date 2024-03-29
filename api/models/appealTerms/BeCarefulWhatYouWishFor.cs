using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class BeCarefulWhatYouWishFor : IAppealTerm
{
    public string Id { get { return "BeCarefulWhatYouWishFor"; } }
    public string Name { get { return "Be careful what you wish for"; } }
    public string PromptLabel { get { return "being granted a wish that comes with consequences"; } }
    public string Description { get { return "Wishes can become curses."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Fantasy }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Concepts }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}