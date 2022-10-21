using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class RealmOfTheDead : IAppealTerm
{
    public string Id { get { return "RealmOfTheDead"; } }
    public string Name { get { return "Realm of the dead"; } }
    public string Description { get { return "The afterlife is a lively place."; } }
    public List<string> Genres { get { return new List<string> { "fantasy" }; } }
    public List<string> Categories { get { return new List<string> { "Setting" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}