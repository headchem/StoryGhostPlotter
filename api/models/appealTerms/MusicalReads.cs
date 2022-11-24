using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class MusicalReads : IAppealTerm
{
    public string Id { get { return "MusicalReads"; } }
    public string Name { get { return "Musical reads"; } }
    public string PromptLabel { get { return "music"; } }
    public string Description { get { return "Featuring performances from musicians, composers, and music lovers."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.History, GenresEnum.Music }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Concepts }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}