using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class SpaceColonization : IAppealTerm
{
    public string Id { get { return "SpaceColonization"; } }
    public string Name { get { return "Space colonization"; } }
    public string PromptLabel { get { return "colonizing the galaxy"; } }
    public string Description { get { return "Humanity puts down roots of civilization on other planets."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.ScienceFiction }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.SpaceAndTime, AppealTermsCategoryEnum.Settings }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}