using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class SuperSubversive : IAppealTerm
{
    public string Id { get { return "SuperSubversive"; } }
    public string Name { get { return "Super subversive"; } }
    public string PromptLabel { get { return "a superhero who undergoes a major change"; } }
    public string Description { get { return "Watch these superheroes undergo a major change."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Action, GenresEnum.Fantasy }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Characters }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}