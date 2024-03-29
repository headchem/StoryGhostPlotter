using System;
using System.Linq;
using System.Collections.Generic;
using StoryGhost.Interfaces;

using StoryGhost.Enums;

namespace StoryGhost.Models.AppealTerms;

public class UnreliableNarrator : IAppealTerm
{
    public string Id { get { return "UnreliableNarrator"; } }
    public string Name { get { return "Unreliable narrator"; } }
    public string PromptLabel { get { return "an unreliable narrator"; } }
    public string Description { get { return "Don't believe everything you read."; } }
    public List<string> Genres { get { return GenresEnum.All; } }
    public List<string> Categories { get { return new List<string> { AppealTermsCategoryEnum.NarrativeDevices }; } }
    public List<string> Aliases { get { return new List<string> { }; } }
    public string GetExampleLogLine(List<string> eras, List<string> locations, List<string> keywords)
    {
        return $"";
    }
}