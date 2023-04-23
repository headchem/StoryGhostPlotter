using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class BeyondTheGrave : IAppealTerm
{
    public string Id { get { return "BeyondTheGrave"; } }
    public string Name { get { return "Beyond the grave"; } }
    public string PromptLabel { get { return "ghosts investigate their own murders from the afterlife"; } }
    public string Description { get { return "Ghosts investigate their own murders from the spiritual realm."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Mystery }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Situations, AppealTermsCategoryEnum.Secrets }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}