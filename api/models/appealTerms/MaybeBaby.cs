using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class MaybeBaby : IAppealTerm
{
    public string Id { get { return "MaybeBaby"; } }
    public string Name { get { return "Maybe baby"; } }
    public string Description { get { return "Adoptions, guardianships, and other non-traditional ways of starting a family or gaining responsibility of a child."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Adventure, GenresEnum.Comedy, GenresEnum.Drama, GenresEnum.Family, GenresEnum.Romance, GenresEnum.War, GenresEnum.Western }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Relationships, AppealTermsCategoryEnum.LifeChallenges }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}