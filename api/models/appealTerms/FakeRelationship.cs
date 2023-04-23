using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class FakeRelationship : IAppealTerm
{
    public string Id { get { return "FakeRelationship"; } }
    public string Name { get { return "Fake relationship"; } }
    public string PromptLabel { get { return "a faked romance becoming real"; } }
    public string Description { get { return "What begins as a pretense ends in happily-ever-after."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Romance }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Relationships, AppealTermsCategoryEnum.Situations }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}