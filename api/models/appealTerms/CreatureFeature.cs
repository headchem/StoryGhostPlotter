using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class CreatureFeature : IAppealTerm
{
    public string Id { get { return "CreatureFeature"; } }
    public string Name { get { return "Creature feature"; } }
    public string Description { get { return "Scary monsters that aren't vampires, witches, zombies, or werewolves."; } }
    public List<string> Genres { get { return new List<string> { "" }; } }
    public List<string> Types { get { return new List<string> { "" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}