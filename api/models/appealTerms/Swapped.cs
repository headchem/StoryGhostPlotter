using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class Swapped : IAppealTerm
{
    public string Id { get { return "Swapped"; } }
    public string Name { get { return "Swapped"; } }
    public string PromptLabel { get { return "characters who swap places"; } }
    public string Description { get { return "These characters have swapped places, and wrestle with their true identities."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Adventure, GenresEnum.Drama, GenresEnum.Family, GenresEnum.History }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Characters, AppealTermsCategoryEnum.LifeChallenges }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}