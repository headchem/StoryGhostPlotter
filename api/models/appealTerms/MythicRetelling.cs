using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class MythicRetelling : IAppealTerm
{
    public string Id { get { return "MythicRetelling"; } }
    public string Name { get { return "Mythic Retelling"; } }
    public string Description { get { return "Classic fairytales retold in a non-traditional setting, with new twists on familiar legends."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Fantasy, GenresEnum.Adventure }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Concepts }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}