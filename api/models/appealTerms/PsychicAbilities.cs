using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class TelepathicHero : IAppealTerm
{
    public string Id { get { return "PsychicAbilities"; } }
    public string Name { get { return "Psychic Abilities"; } }
    public string Description { get { return "These characters possess psychic abilities like telepathy, telekinesis, and mystic visions or mental links to other minds."; } }
    public List<string> Genres { get { return new List<string> { "fantasy" }; } }
    public List<string> Categories { get { return new List<string> { "Characters" }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}