using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class CriminalMasterpieces : IAppealTerm
{
    public string Id { get { return "CriminalMasterpieces"; } }
    public string Name { get { return "Criminal masterpieces"; } }
    public string Description { get { return "Art heists, forgeries, and other crimes against culture."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Mystery, GenresEnum.History }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Settings, AppealTermsCategoryEnum.Concepts }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}