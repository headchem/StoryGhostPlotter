using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class InspiredByRealEvents : IAppealTerm
{
    public string Id { get { return "InspiredByRealEvents"; } }
    public string Name { get { return "Inspired by real events"; } }
    public string PromptLabel { get { return "a real event"; } }
    public string Description { get { return "Sometimes truth is stranger than fiction. Ripped from the headlines, deadly danger awaits in our everyday lives."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Crime, GenresEnum.Mystery, GenresEnum.Thriller }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Settings }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}