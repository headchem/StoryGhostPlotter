using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class DystopiaUtopia : IAppealTerm
{
    public string Id { get { return "DystopiaUtopia"; } }
    public string Name { get { return "Dystopia or Utopia"; } }
    public string PromptLabel { get { return "dystopia or utopia"; } }

    public string Description { get { return "Engineered societies forcing a central vision upon the masses."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Fantasy, GenresEnum.ScienceFiction, GenresEnum.Urban }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.ApocalypticAndDystopian, AppealTermsCategoryEnum.PowerStructures, AppealTermsCategoryEnum.Settings }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}