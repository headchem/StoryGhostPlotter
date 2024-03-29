using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class MovingToAHauntedHouse : IAppealTerm
{
    public string Id { get { return "MovingToAHauntedHouse"; } }
    public string Name { get { return "Moving to a haunted house"; } }
    public string PromptLabel { get { return "moving into a haunted house"; } }
    public string Description { get { return "After moving, it's apparent the house still has ghostly residents who disapprove of the new tenants."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Horror }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Settings, AppealTermsCategoryEnum.Situations }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}