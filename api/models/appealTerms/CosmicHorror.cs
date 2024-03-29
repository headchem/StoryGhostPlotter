using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class CosmicHorror : IAppealTerm
{
    public string Id { get { return "CosmicHorror"; } }
    public string Name { get { return "Cosmic horror"; } }
    public string PromptLabel { get { return "horror beyond human comprehension"; } }
    public string Description { get { return "Horror beyond human understanding."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Horror }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Style }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}