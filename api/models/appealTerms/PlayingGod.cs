using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class PlayingGod : IAppealTerm
{
    public string Id { get { return "PlayingGod"; } }
    public string Name { get { return "Playing God"; } }
    public string Description { get { return "Humankind's scientific overreach leads to conflict with nature."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.ScienceFiction, GenresEnum.History, GenresEnum.Thriller, GenresEnum.Horror }; } }
    public List<string> Categories { get { return new List<string> { "Concepts and Characters", "Plot" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}