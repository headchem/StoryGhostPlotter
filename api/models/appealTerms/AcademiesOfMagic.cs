using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class AcademiesOfMagic : IAppealTerm
{
    public string Id { get { return "AcademiesOfMagic"; } }
    public string Name { get { return "Academies of magic"; } }
    public string PromptLabel { get { return "characters learn to wield magic"; } }
    public string Description { get { return "Special schools and apprenticeships for the magically gifted."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Fantasy }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Settings }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}