using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class CreatureFeature : IAppealTerm
{
    public string Id { get { return "CreatureFeature"; } }
    public string Name { get { return "Creature feature"; } }
    public string PromptLabel { get { return "indescribable and unfamiliar monsters"; } }
    public string Description { get { return "Scary monsters that are indescribable and unfamiliar."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Horror }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Monsters }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}