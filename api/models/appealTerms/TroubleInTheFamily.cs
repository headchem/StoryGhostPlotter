using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class TroubleInTheFamily : IAppealTerm
{
    public string Id { get { return "TroubleInTheFamily"; } }
    public string Name { get { return "Trouble in the Family"; } }
    public string PromptLabel { get { return "a dysfunctional family and their relationship problems"; } }
    public string Description { get { return "There's trouble in the family, as these characters struggle to mend family relationships and escape their problems."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Drama, GenresEnum.Urban }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Relationships, AppealTermsCategoryEnum.LifeChallenges }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}