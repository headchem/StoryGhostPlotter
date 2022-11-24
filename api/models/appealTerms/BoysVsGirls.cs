using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class BoysVsGirls : IAppealTerm
{
    public string Id { get { return "BoysVsGirls"; } }
    public string Name { get { return "Boys vs Girls"; } }
    public string PromptLabel { get { return "boys vs girls"; } }
    public string Description { get { return "It's a battle of the sexes as characters divide along gender lines."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Comedy, GenresEnum.Family }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Concepts, AppealTermsCategoryEnum.Characters }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}