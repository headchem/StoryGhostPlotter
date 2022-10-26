using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class CorruptionPermeates : IAppealTerm
{
    public string Id { get { return "CorruptionPermeates"; } }
    public string Name { get { return "Corruption Permeates"; } }
    public string Description { get { return "What hope does a honest person have when surrounded by corruption?"; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Action, GenresEnum.Crime, GenresEnum.Drama, GenresEnum.Thriller, GenresEnum.Urban }; } }
    public List<string> Categories { get { return new List<string> { "Setting" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}