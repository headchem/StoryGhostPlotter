using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class EnemiesToLovers : IAppealTerm
{
    public string Id { get { return "EnemiesToLovers"; } }
    public string Name { get { return "Enemies to lovers"; } }
    public string PromptLabel { get { return "enemies turning into lovers"; } }
    public string Description { get { return "The line between love and hate can be very thin."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Romance }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Characters, AppealTermsCategoryEnum.Relationships }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}