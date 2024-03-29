using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class SnowboundAndStranded : IAppealTerm
{
    public string Id { get { return "SnowboundAndStranded"; } }
    public string Name { get { return "Snowbound And stranded"; } }
    public string PromptLabel { get { return "romance developing when couples are trapped together in close quarters"; } }
    public string Description { get { return "Romance heats up in close quarters when these couples are forced to spend time together."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Romance }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Settings, AppealTermsCategoryEnum.Relationships }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}