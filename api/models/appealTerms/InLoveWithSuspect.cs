using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class InLoveWithSuspect : IAppealTerm
{
    public string Id { get { return "InLoveWithSuspect"; } }
    public string Name { get { return "In Love With Suspect"; } }
    public string PromptLabel { get { return "an investigator falling in love with the primary suspect of a crime"; } }
    public string Description { get { return "Can the investigator stay objective when they fall in love with a suspect?"; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Mystery, GenresEnum.Romance }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Characters, AppealTermsCategoryEnum.Relationships }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}