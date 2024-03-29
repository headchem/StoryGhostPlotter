using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class ProtectFromTheUnseen : IAppealTerm
{
    public string Id { get { return "ProtectFromTheUnseen"; } }
    public string Name { get { return "Protect From The Unseen"; } }
    public string PromptLabel { get { return "one who protects the unaware public from an unseen and paranormal threat"; } }
    public string Description { get { return "The protagonist protects the unaware public from paranormal threats."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Fantasy, GenresEnum.Thriller, GenresEnum.Action }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Characters, AppealTermsCategoryEnum.Concepts }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}