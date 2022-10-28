using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class CopingWithDeath : IAppealTerm
{
    public string Id { get { return "CopingWithDeath"; } }
    public string Name { get { return "Coping with death"; } }
    public string Description { get { return "Characters navigate grief following the loss of a loved one."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Drama, GenresEnum.Family, GenresEnum.Urban, GenresEnum.War, GenresEnum.Western }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.LifeChallenges }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}