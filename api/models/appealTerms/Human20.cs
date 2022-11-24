using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class Human20 : IAppealTerm
{
    public string Id { get { return "Human20"; } }
    public string Name { get { return "Human 2.0"; } }
    public string PromptLabel { get { return "enhancing the human body with technology"; } }
    public string Description { get { return "A distinct upgrade from your run-of-the-mill human."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.ScienceFiction }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Characters }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}