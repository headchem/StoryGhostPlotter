using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class SpyLifeBravado : IAppealTerm
{
    public string Id { get { return "SpyLifeBravado"; } }
    public string Name { get { return "Spy Life Bravado"; } }
    public string PromptLabel { get { return "a charming and self-confident spy"; } }
    public string Description { get { return "These special agents are the best of the best, and they know it. Trained by the government with gadgets galore - these spies have a tendency to break to rules to accomplish their mission."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Action, GenresEnum.History, GenresEnum.Thriller, GenresEnum.War }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Characters, AppealTermsCategoryEnum.OccupationsAndEnterprise }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}