using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class MeAndMyPet : IAppealTerm
{
    public string Id { get { return "MeAndMyPet"; } }
    public string Name { get { return "Me and my pet"; } }
    public string Description { get { return "These stories highlight the powerful bond between these characters and pets."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Adventure, GenresEnum.Family }; } }
    public List<string> Categories { get { return new List<string> { "Concepts and Characters" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}