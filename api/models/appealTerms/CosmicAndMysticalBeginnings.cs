using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class CosmicAndMysticalBeginnings : IAppealTerm
{
    public string Id { get { return "CosmicAndMysticalBeginnings"; } }
    public string Name { get { return "Cosmic and mystical beginnings"; } }
    public string PromptLabel { get { return "a character of supernatural origin"; } }
    public string Description { get { return "Part superhero, part wizard or god."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Adventure, GenresEnum.Fantasy }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Characters }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}