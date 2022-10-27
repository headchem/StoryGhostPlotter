using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class LifeInSlavery : IAppealTerm
{
    public string Id { get { return "LifeInSlavery"; } }
    public string Name { get { return "Life in slavery"; } }
    public string Description { get { return "Enslaved characters struggle under the brutality and injustice of slavery."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Action, GenresEnum.Drama, GenresEnum.History, GenresEnum.Horror, GenresEnum.Urban, GenresEnum.War }; } }
    public List<string> Categories { get { return new List<string> { "Historical" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}