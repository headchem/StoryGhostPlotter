using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class LoveOnTheRocks : IAppealTerm
{
    public string Id { get { return "LoveOnTheRocks"; } }
    public string Name { get { return "Love on the rocks"; } }
    public string PromptLabel { get { return "a romantic relationship falling apart"; } }
    public string Description { get { return "The course of love does not always run smooth."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Comedy, GenresEnum.Drama, GenresEnum.Romance, GenresEnum.Urban }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Relationships }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}