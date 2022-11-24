using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class UrbanPolice : IAppealTerm
{
    public string Id { get { return "UrbanPolice"; } }
    public string Name { get { return "Urban police"; } }
    public string PromptLabel { get { return "big city police"; } }
    public string Description { get { return "Crime never sleeps in the city."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Crime, GenresEnum.Urban }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Settings }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}