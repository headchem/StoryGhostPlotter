using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class HumanAndAnimalBonds : IAppealTerm
{
    public string Id { get { return "HumanAndAnimalBonds"; } }
    public string Name { get { return "Human and animal bonds"; } }
    public string PromptLabel { get { return "a relationship with an animal"; } }
    public string Description { get { return "These stories explore our relationships with animals."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Adventure, GenresEnum.Family, GenresEnum.Western }; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.Animals, AppealTermsCategoryEnum.Concepts }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}