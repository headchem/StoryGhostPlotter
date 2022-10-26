using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class CreepyClownsAndBadSeeds : IAppealTerm
{
    public string Id { get { return "CreepyClownsAndBadSeeds"; } }
    public string Name { get { return "Creepy clowns and bad seeds"; } }
    public string Description { get { return "Menace lurks behind things that seem innocent."; } }
    public List<string> Genres { get { return new List<string> { GenresEnum.Horror }; } }
    public List<string> Categories { get { return new List<string> { "Monsters" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}