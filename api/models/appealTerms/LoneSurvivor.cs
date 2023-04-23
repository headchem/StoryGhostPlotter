using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class LoneSurvivor : IAppealTerm
{
    public string Id { get { return "LoneSurvivor"; } }
    public string Name { get { return "Lone Survivor"; } }
    public string PromptLabel { get { return "lone survivor of a horrific event"; } }
    public string Description { get { return "The lone survivor of a horrific event must fight to survive."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Horror, GenresEnum.Fantasy, GenresEnum.ScienceFiction }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Characters, AppealTermsCategoryEnum.Situations }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}