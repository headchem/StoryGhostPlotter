using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class WesternsUnromanticized : IAppealTerm
{
    public string Id { get { return "WesternsUnromanticized"; } }
    public string Name { get { return "Unromanticized"; } }
    public string PromptLabel { get { return "the ugly underbelly of real life in the Wild West"; } }
    public string Description { get { return "These Westerns reveal the ugly underbelly of the West, with the patina of a glamorized frontier rubbed away to give a grim, uncompromising view of the area and times."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Western, GenresEnum.Urban }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Settings }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}