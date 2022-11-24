using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class RuralPolice : IAppealTerm
{
    public string Id { get { return "RuralPolice"; } }
    public string Name { get { return "Rural police"; } }
    public string PromptLabel { get { return "crime in rural areas"; } }
    public string Description { get { return "Crime is not absent in rural areas... it's just more spread out."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Crime, GenresEnum.Mystery }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Settings }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}