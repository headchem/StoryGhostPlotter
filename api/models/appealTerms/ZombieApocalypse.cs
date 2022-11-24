using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class ZombieApocalypse : IAppealTerm
{
    public string Id { get { return "ZombieApocalypse"; } }
    public string Name { get { return "Zombie apocalypse"; } }
    public string PromptLabel { get { return "zombies"; } }
    public string Description { get { return "The dead are reanimated and roaming, looking for a meal."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Horror }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Monsters }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}