using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

namespace StoryGhost.Models.AppealTerms;

public class CreatureFeature : IAppealTerm
{
    public string Id { get { return "CreatureFeature"; } }
    public string Name { get { return "Creature feature"; } }
    public string Description { get { return "Scary monsters that are unlike anything you can describe."; } }
    public List<string> Genres { get { return new List<string> { "horror" }; } }
    public List<string> Types { get { return new List<string> { "Monsters" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}