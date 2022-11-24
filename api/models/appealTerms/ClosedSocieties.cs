using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class ClosedSocieties : IAppealTerm
{
    public string Id { get { return "ClosedSocieties"; } }
    public string Name { get { return "Closed Societies"; } }
    public string PromptLabel { get { return "secretive and insular societies"; } }
    public string Description { get { return "Murder in insular societies or cultures, like a small village that doesn't welcome outsiders, or an opulent manor (and its locked rooms)."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Mystery }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Settings, AppealTermsCategoryEnum.PowerStructures }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}