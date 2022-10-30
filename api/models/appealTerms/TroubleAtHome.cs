using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class TroubleAtHome : IAppealTerm
{
    public string Id { get { return "TroubleAtHome"; } }
    public string Name { get { return "Trouble at home"; } }
    public string Description { get { return "Life at home isn't going well, as these characters struggle to mend family relationships and escape their problems."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Drama, GenresEnum.Urban }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Relationships, AppealTermsCategoryEnum.LifeChallenges }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}