using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class ToxicRelationships : IAppealTerm
{
    public string Id { get { return "ToxicRelationships"; } }
    public string Name { get { return "Toxic relationships"; } }
    public string PromptLabel { get { return "a toxic relationship"; } }
    public string Description { get { return "Intense characters interact in unhealthy ways."; } }
    public List<string> Genres { get { return GenresEnum.All; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Relationships, AppealTermsCategoryEnum.LifeChallenges }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}