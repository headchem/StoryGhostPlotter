using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class RichAndFamous : IAppealTerm
{
    public string Id { get { return "RichAndFamous"; } }
    public string Name { get { return "Rich and famous"; } }
    public string PromptLabel { get { return "the rich and famous"; } }
    public string Description { get { return "Saturated with celebrity culture."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Adventure, GenresEnum.Comedy, GenresEnum.Crime, GenresEnum.Drama, GenresEnum.History, GenresEnum.Music, GenresEnum.Mystery, GenresEnum.Romance, GenresEnum.Sports }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Characters }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}