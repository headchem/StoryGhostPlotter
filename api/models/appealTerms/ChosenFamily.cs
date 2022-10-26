using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class ChosenFamily : IAppealTerm
{
    public string Id { get { return "ChosenFamily"; } }
    public string Name { get { return "Chosen family"; } }
    public string Description { get { return "Stories about finding family."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Adventure, GenresEnum.Comedy, GenresEnum.Drama, GenresEnum.Family, GenresEnum.Fantasy, GenresEnum.Music, GenresEnum.Sports, GenresEnum.Western }; } }
    public List<string> Categories { get { return new List<string> { "Family and Relationships" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}