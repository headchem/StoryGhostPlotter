using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class ClimateChangeApocalypse : IAppealTerm
{
    public string Id { get { return "ClimateChangeApocalypse"; } }
    public string Name { get { return "Climate change apocalypse"; } }
    public string PromptLabel { get { return "apocalyptic changes to the climate and natural environment"; } }
    public string Description { get { return "Weathering devastating environmental change."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Action, GenresEnum.History, GenresEnum.Urban, GenresEnum.Western, GenresEnum.ScienceFiction }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.ApocalypticAndDystopian }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}