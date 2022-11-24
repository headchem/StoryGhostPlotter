using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class CatAndMouse : IAppealTerm
{
    public string Id { get { return "CatAndMouse"; } }
    public string Name { get { return "Cat And Mouse"; } }
    public string PromptLabel { get { return "constant pursuit and near captures"; } }
    public string Description { get { return "Both the hero and villain are one step ahead of each other."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Thriller, GenresEnum.Crime, GenresEnum.Mystery }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Concepts, AppealTermsCategoryEnum.Characters }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}