using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class FlawedSwashbuckler : IAppealTerm
{
    public string Id { get { return "FlawedSwashbuckler"; } }
    public string Name { get { return "Flawed Swashbuckler"; } }
    public string PromptLabel { get { return "a carefree hero who is always getting into trouble"; } }
    public string Description { get { return "This flawed hero always seems to end up in trouble. Are they on a quest with a plan, or just winging it?"; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Action, GenresEnum.Adventure, GenresEnum.Fantasy, GenresEnum.Comedy, GenresEnum.History, GenresEnum.ScienceFiction, GenresEnum.Western }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Characters }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}