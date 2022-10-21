using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class MissingMemories : IAppealTerm
{
    public string Id { get { return "MissingMemories"; } }
    public string Name { get { return "Missing memories"; } }
    public string Description { get { return "A gap in memory conceals vital information."; } }
    public List<string> Genres { get { return new List<string> { "mystery", "thriller" }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Characters, AppealTermsCategoryEnum.Secrets }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}