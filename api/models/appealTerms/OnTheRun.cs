using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class OnTheRun : IAppealTerm
{
    public string Id { get { return "OnTheRun"; } }
    public string Name { get { return "On the run"; } }
    public string Description { get { return "Sometimes flight beats fight!"; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Action, GenresEnum.Adventure, GenresEnum.Horror, GenresEnum.Thriller, GenresEnum.War, GenresEnum.Western }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Situations }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}