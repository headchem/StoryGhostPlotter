using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class SetTheStage : IAppealTerm
{
    public string Id { get { return "SetTheStage"; } }
    public string Name { get { return "Set the stage"; } }
    public string Description { get { return "All the world's a stage in these stories about actors."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Adventure, GenresEnum.Comedy, GenresEnum.History, GenresEnum.Music, GenresEnum.Western }; } }
    public List<string> Categories { get { return new List<string> { "Personal Development" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}