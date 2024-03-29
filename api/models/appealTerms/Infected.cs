using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class Infected : IAppealTerm
{
    public string Id { get { return "Infected"; } }
    public string Name { get { return "Infected"; } }
    public string PromptLabel { get { return "a mysterious disease sweeping the land"; } }
    public string Description { get { return "A mysterious disease is sweeping the land, turning everyday living into a nightmare. Both infected and uninfected must struggle to survive."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Horror, GenresEnum.History, GenresEnum.Thriller }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.ApocalypticAndDystopian, AppealTermsCategoryEnum.Situations }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}